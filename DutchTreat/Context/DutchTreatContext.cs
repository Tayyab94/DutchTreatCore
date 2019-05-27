using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DutchTreat.Context
{
    public class DutchTreatContext:DbContext
    {
        public DutchTreatContext(DbContextOptions<DutchTreatContext>options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public  DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
