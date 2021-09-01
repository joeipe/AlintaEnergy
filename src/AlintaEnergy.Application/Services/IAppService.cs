using AlintaEnergy.ViewModels;
using System.Collections.Generic;

namespace AlintaEnergy.Application.Services
{
    public interface IAppService
    {
        void AddCustomer(CustomerVM value);
        void DeleteCustomer(int id);
        CustomerVM GetCustomerById(int id);
        List<CustomerVM> GetCustomersSearch(string search);
        List<CustomerVM> GetCustomers();
        void UpdateCustomer(CustomerVM value);
    }
}