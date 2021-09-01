using AlintaEnergy.Application.AutoMapper;
using AlintaEnergy.Application.Services;
using AlintaEnergy.Data;
using AlintaEnergy.Data.Services;
using AutoMapper;
using DataContext.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlintaEnergy.Tests
{
    public class UnitTest1
    {
        private static IMapper _mapper;
        private List<Customer> _customersInMemory;

        public UnitTest1()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfiles(new List<Profile> { new DomainToViewModelMappingProfile(), new ViewModelToDomainMappingProfile() });
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void Can_GetCustomers()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<Data.DataContext>();
            builder.UseInMemoryDatabase("GetCustomers");
            SeedInMemoryStore(builder.Options);

            //Act
            using (var dataContext = new Data.DataContext(builder.Options))
            {

                var appService = new AppService(_mapper, new DataService(new Uow(dataContext)));
                var result = appService.GetCustomers();

                // Assert
                Assert.Equal(_customersInMemory.Count(), result.Count());
            }
        }

        [Fact]
        public void Can_GetCustomerById()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<Data.DataContext>();
            builder.UseInMemoryDatabase("GetCustomerById");
            SeedInMemoryStore(builder.Options);

            //Act
            using (var dataContext = new Data.DataContext(builder.Options))
            {

                var appService = new AppService(_mapper, new DataService(new Uow(dataContext)));
                var result = appService.GetCustomerById(1);

                // Assert
                Assert.Equal("Joe", result.FirstName);
                Assert.Equal("Ipe", result.LastName);
            }
        }

        [Fact]
        public void Can_GetCustomersSearch()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<Data.DataContext>();
            builder.UseInMemoryDatabase("GetCustomersSearch");
            SeedInMemoryStore(builder.Options);

            //Act
            using (var dataContext = new Data.DataContext(builder.Options))
            {

                var appService = new AppService(_mapper, new DataService(new Uow(dataContext)));
                var result = appService.GetCustomersSearch("John");

                // Assert
                Assert.Equal("John", result.First().FirstName);
            }
        }

        private void SeedInMemoryStore(DbContextOptions<Data.DataContext> options)
        {
            var customer1 = new Customer() { Id = 1, FirstName = "Joe", LastName = "Ipe", DoB = DateTime.Now };
            var customer2 = new Customer() { Id = 2, FirstName = "John", LastName = "Doe", DoB = DateTime.Now };

            _customersInMemory = new List<Customer>() { customer1, customer2 };

            using (var context = new Data.DataContext(options))
            {
                context.Customers.AddRange(
                        _customersInMemory
                    );

                context.SaveChanges();
            }
        }
    }
}
