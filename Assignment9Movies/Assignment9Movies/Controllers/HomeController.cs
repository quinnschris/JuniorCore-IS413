using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment9Movies.Models;

namespace Assignment9Movies.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _context { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MoviesContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie m)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(m);
                _context.SaveChanges();
                return View("ViewMovies", _context.Movies.Where(x => x.Title != "Independence Day"));
            }
            else
            {
                return View();
            }
        }

        public IActionResult ViewMovies()
        {
            return View("ViewMovies", _context);
        }

        public IActionResult Privacy()
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
