using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReTP3.Models;

namespace ReTP3.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _db;
        
        public MovieController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Movie> movies = _db.movies.ToList();
            return View(movies);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.File != null)
                {
                    var fileName = Path.GetFileName(movie.File.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await movie.File.CopyToAsync(fileSteam);
                    }
                    movie.Photo = fileName;  // Set the file name
                }
                _db.movies.Add(movie);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
        
    }
}

