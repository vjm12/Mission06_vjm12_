using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_vjm12.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_vjm12.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //Get information to and from database
        private NewMovieContext movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, NewMovieContext NMC)
        {
            _logger = logger;
            movieContext = NMC;
        }

        public IActionResult Index()
        {
            return View();
        }
        //Show form view
        [HttpGet]
        public IActionResult NewMoviesForm()
        {
            return View();
        }
        //Show confirmation view 
        [HttpPost]
        //Use if statement to ensure validation. Also add to database
        public IActionResult NewMoviesForm(NewMovie nm)
        {   if (ModelState.IsValid)
            {
                movieContext.Add(nm);
                movieContext.SaveChanges();

                return View("Confirmation",nm);
            }
            else
            {
                return View();
            }
           
        }
        public IActionResult Podcasts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
