using DataContext.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace AlintaEnergy.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
