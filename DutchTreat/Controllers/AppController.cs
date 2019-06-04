using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {

        private readonly IMailService _mailService;
        private readonly IDutchRepository _repository;
        //Replace context with repo?
        //private readonly DutchContext _ctx;
        public AppController(IMailService mailService, IDutchRepository repository)
        {
            _mailService = mailService;
            //make calls through repo
            _repository = repository;
        }
        public IActionResult Index()
        {
            //var results = _ctx.Products.ToList();
            return View();
        }
        //app/contact -> /contact
        [HttpGet("contact")]
        public IActionResult Contact()
        {
 
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //do stuff
                _mailService.SendMessage("cullen@gmail.com", model.Subject, model.Message);
                ViewBag.UserMessage = "mail sent";
            }
            else
            {
                //errors
            }

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }

        [Authorize]
        public IActionResult Shop()
        {
            //from p in _context.Products 
            //orderby p.Category
            //select p;
            //Use repo Instead of doing it through directly
            //var results = _ctx.Products
            //    .OrderBy(p => p.Category)
            //    .ToList();

            var results = _repository.GetAllProducts();

            //passing data to view
            return View(results);
        }
    }
}
