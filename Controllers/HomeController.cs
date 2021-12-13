/*
Communication Activity 5
December 12th, 2021
Adonai Ford-Williams
NETD3202
*/
using Lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Lab5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        /*
        [HttpGet]
        public IActionResult ViewOrder()
        {
            return View();
        }

        [HttpPost]
        // New View after submission
        public IActionResult ViewOrder(Purchased order)
        {
            if (ModelState.IsValid)
            {
                // Print user input
                ViewData["Message"] = order.ToString();
                return View("ViewOrder", order);
            }
            else
            {
                // Print error message
                ViewData["Message"] = "An error has occurred. Please try again.";
                return View("Error", order);
            }
        }
        */
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
