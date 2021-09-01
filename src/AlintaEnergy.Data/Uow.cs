using DataContext.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlintaEnergy.Data
{
    public class Uow : IDisposable
    {
        private readonly DataContext _context;

        public Uow(DataContext context)
        {
            _context = context;
        }

        public GenericRepository<Customer> CustomersRepo { get { return new GenericRepository<Customer>(_context); } }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
