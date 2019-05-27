using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Context;
using DutchTreat.Data;
using DutchTreat.services;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {

        private readonly IMailService _mailService;
        private readonly IDutchRepository _repository;
        private readonly DutchTreatContext _context;

        //public AppController(IMailService mailService, DutchTreatContext context)
        //{
        //    _mailService = mailService;
        //    _context = context;
        //}

        public AppController(IMailService mailService,IDutchRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
       
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet("Contact-With-Tayyab")]
        public IActionResult ContactUs()
        {

            return View();
        }

        [HttpPost("Contact-With-Tayyab")]
        public IActionResult ContactUs(ContactUsViewModel something)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("admin@gail.com", something.Name,
                    $"Form :{something.Email}, Message{something.Name} {something.Password}");

                ViewBag.userMessage = "Send";
                ModelState.Clear();
            }
            else
            {
                return View(something);
            }
            return View();
        }

        public IActionResult Shop()
        {
            //var products = (from p in _context.Products
            //                orderby p.Category
            //                select p).ToList();

            var products = _repository.GetProducts();
            return View(products);
        }

    }
}
