using System.Collections.Generic;
using DutchTreat.Data.Entities;

namespace DutchTreat.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        bool SaveData();
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int id);
        void Add(object model);
    }
}