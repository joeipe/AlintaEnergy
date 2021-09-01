using AlintaEnergy.Data.Services;
using AlintaEnergy.ViewModels;
using AutoMapper;
using DataContext.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlintaEnergy.Application.Services
{
    public class AppService : IAppService
    {
        private readonly IMapper _mapper;
        private readonly IDataService _dataService;

        public AppService(IMapper mapper, IDataService dataService)
        {
            _mapper = mapper;
            _dataService = dataService;
        }

        public List<CustomerVM> GetCustomers()
        {
            var data = _dataService.GetCustomers();
            var vm = _mapper.Map<List<CustomerVM>>(data);
            return vm;
        }

        public CustomerVM GetCustomerById(int id)
        {
            var data = _dataService.GetCustomerById(id);
            var vm = _mapper.Map<CustomerVM>(data);
            return vm;
        }

        public List<CustomerVM> GetCustomersSearch(string search)
        {
            var data = _dataService.GetCustomersSearch(search);
            var vm = _mapper.Map<List<CustomerVM>>(data);
            return vm;
        }

        public void AddCustomer(CustomerVM value)
        {
            var data = _mapper.Map<Customer>(value);
            _dataService.AddCustomer(data);
        }

        public void UpdateCustomer(CustomerVM value)
        {
            var data = _mapper.Map<Customer>(value);
            _dataService.UpdateCustomer(data);
        }

        public void DeleteCustomer(int id)
        {
            _dataService.DeleteCustomer(id);
        }
    }
}
