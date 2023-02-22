using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //Get information to and from database
        private NewMovieContext movieContext { get; set; }

        public HomeController( NewMovieContext NMC)
        {
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
            ViewBag.Categories = movieContext.Categories.ToList();
            return View();
        }
        //Show confirmation view 
        [HttpPost]
        //Use if statement to ensure validation. Also add to database
        public IActionResult NewMoviesForm(NewMovie nm)
        {   
            if (ModelState.IsValid)
            {
                movieContext.Add(nm);
                movieContext.SaveChanges();

                return View("Confirmation",nm);
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();
                return View(nm);
            }
           
        }
        public IActionResult Podcasts()
        {
            return View();
        }
        public IActionResult AllMovies()
        {
            //Put movies into a list and alphabetically by title and include category object
            var moviess = movieContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.MovieTitle)
                .ToList();

            return View(moviess);
        }
        //Get information from existing record and put it into the edit form
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var movieform = movieContext.Movies.Single(x => x.MovieID ==movieid);
            return View("NewMoviesForm",movieform);
        }
        //Save changes made to edit record and redirect
        [HttpPost]
        public IActionResult Edit(NewMovie nm)
        {
            movieContext.Update(nm);
            movieContext.SaveChanges();

            return RedirectToAction("AllMovies");
        }
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = movieContext.Movies.Single(x => x.MovieID == movieid);

            return View(movie);
        }
        //If the user selects delete, then get the id and delete and redirect
        [HttpPost]
        public IActionResult Delete(NewMovie nm)
        {
            movieContext.Movies.Remove(nm);
            movieContext.SaveChanges();
            return RedirectToAction("AllMovies");

        }
    }
}
