using CrudMvc.Database;
using CrudMvc.Domain;
using CrudMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMvc.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieDatabase movieDatabase;
        public MovieController(IMovieDatabase movieDatabase)
        {
            this.movieDatabase = movieDatabase;
        }
        public IActionResult Index()
        {
            var vm = movieDatabase.GetMovies().Select(x => new MovieListViewModel
            {
                Title = x.Title,
                Description = x.Description,
                Id = x.Id
            });

            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] MovieCreateViewModel movie)
        {
            if (TryValidateModel(movie))
            {
                movieDatabase.Insert(new Movie
                {
                    Title = movie.Title,
                    Description = movie.Description,
                    Genre = movie.Genre
                });
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
