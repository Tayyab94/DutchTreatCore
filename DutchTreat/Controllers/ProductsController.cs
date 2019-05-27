using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Data;
using Microsoft.Extensions.Logging;
using DutchTreat.Data.Entities;

namespace DutchTreat.Controllers
{

    [Route("api/[Controller]")]
    public class ProductsController:Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<ProductsController> loger;

        public ProductsController(IDutchRepository repository,ILogger<ProductsController> loger)
        {
           _repository = repository;
            this.loger = loger;
        }


        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repository.GetProducts();
        }
    }

}
