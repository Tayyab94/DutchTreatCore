using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Controllers
{
 [Route("api/[Controller]")]
    public class OrderController:Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IDutchRepository repository,ILogger<OrderController> logger)
        {
            _repository = repository;
            _logger = logger;
        }



        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                return Ok(_repository.GetOrders());
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed To get teh Orders {e}");

                return BadRequest("Fail to get Orders");
             
            }
        }

        [HttpGet("{id:int}")]
  
        public IActionResult GetOrderById(int id)
        {
            try
            {
                var order = _repository.GetOrderById(id);
                if (order != null) return Ok(order);
                else return NotFound();
            }
            catch (Exception e)
            {

                _logger.LogError($"Fail to get Order {e}");

                return BadRequest("Fail to get Order");
                throw;
            }
        }

        //[HttpPost]
        //public IActionResult Post([FromBody]Order model)
        //{

        //    try
        //    {
        //        //Poster
        //        model.Items = new List<OrderItem>()
        //        {
        //            new OrderItem
        //            {
        //                Product = _repository.GetProductsByCategory("Poster").FirstOrDefault(),
        //                Quantity = 4,
        //                UnitPrice = _repository.GetProductsByCategory("Poster").First().Price
        //            }
        //        };
        //        _repository.Add(model);
        //        if (_repository.SaveData())
        //        {
        //            return Created($"/api/order/{model.Id}", model);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError($"Fail to get Order {e}");

        //        return BadRequest("Fail to get Order");
        //    }

        //    return BadRequest("Fail to save New order");
        //}


        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = new Order()
                    {
                        Items = new List<OrderItem>()
                        {
                            new OrderItem
                            {
                                Product = _repository.GetProductsByCategory("Poster").FirstOrDefault(),
                                Quantity = 4,
                                UnitPrice = _repository.GetProductsByCategory("Poster").First().Price
                            }
                        },
                        OrderDate = model.orderDate,
                        OrderNumber = model.orderNumber,
                        Id = model.orderId
                    };


                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    _repository.Add(newOrder);
                    if (_repository.SaveData())
                    {
                        var vm = new OrderViewModel
                        {
                            orderId = newOrder.Id,
                            orderDate = newOrder.OrderDate,
                            orderNumber = newOrder.OrderNumber
                        };

                        return Created($"/api/order/{vm.orderId}", vm);
                    }
                }
                else
                {
                    return BadRequest(model);
                }
             
            }
            catch (Exception e)
            {
                _logger.LogError($"Fail to get Order {e}");

                return BadRequest("Fail to get Order");
            }

            return BadRequest("Fail to save New order");
        }
    }
}
