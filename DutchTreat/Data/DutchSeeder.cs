using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Context;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.Semantics;
using Newtonsoft.Json;

namespace DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchTreatContext _context;
        private readonly IHostingEnvironment _iHostingEnvironment;

        public DutchSeeder(DutchTreatContext context, IHostingEnvironment iHostingEnvironment)
        {
            _context = context;
            this._iHostingEnvironment = iHostingEnvironment;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Products.Any())
            {

                //need To creat the data

                var filepath = Path.Combine(_iHostingEnvironment.ContentRootPath, "Data/art.json");
                //File.ReadAllText(filepath);
                //var json = File.ReadAllText(filepath);

                //var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(File.ReadAllText(filepath));

                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(File.ReadAllText(filepath));
                _context.Products.AddRange(products);

                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    OrderNumber = "1234",
                    Items = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    }
                };

                _context.Orders.AddRange(order);


                _context.SaveChanges();

            }
        }
    }
}
