using DataContext.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlintaEnergy.Data.Services
{
    public interface IDataService
    {
        void AddCustomer(Customer data);
        void DeleteCustomer(int id);
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetCustomersSearch(string search);
        IEnumerable<Customer> GetCustomers();
        void UpdateCustomer(Customer data);
    }
}
