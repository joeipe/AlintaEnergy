using DataContext.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlintaEnergy.Data.Services
{
    public class DataService : IDataService
    {
        private readonly Uow _uow;

        public DataService(Uow uow)
        {
            _uow = uow;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var data = _uow.CustomersRepo.GetAll();
            return data;
        }

        public Customer GetCustomerById(int id)
        {
            var data = _uow.CustomersRepo.SearchFor
                (
                    p => p.Id == id
                ).FirstOrDefault();
            return data;
        }

        public IEnumerable<Customer> GetCustomersSearch(string search)
        {
            var data = _uow.CustomersRepo.SearchFor
                (
                    p => p.FirstName.Contains(search) || p.LastName.Contains(search)
                );
            return data;
        }

        public void AddCustomer(Customer data)
        {
            _uow.CustomersRepo.Create(data);
            _uow.Save();
        }

        public void UpdateCustomer(Customer data)
        {
            _uow.CustomersRepo.Update(data);
            _uow.Save();
        }

        public void DeleteCustomer(int id)
        {
            _uow.CustomersRepo.Delete(id);
            _uow.Save();
        }
    }
}
