using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Context;
using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchTreatContext _Context;

        public DutchRepository(DutchTreatContext _context)
        {
            _Context = _context;
        }

        public void Add(object model)
        {
            _Context.Add(model);
        }

        public Order GetOrderById(int id)
        {

            return _Context.Orders.Include(x => x.Items).ThenInclude(x => x.Product)
                .Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Order> GetOrders()
        {
            return _Context.Orders.Include(x=>x.Items).ThenInclude(x=>x.Product).ToList();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _Context.Products.OrderBy(x => x.Title).ToList();

        }


        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _Context.Products.Where(x => x.Category == category).ToList();
        }

        public bool SaveData()
        {
            return _Context.SaveChanges() > 0;
        }
    }
}
