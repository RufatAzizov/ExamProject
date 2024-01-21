using Exam.Contexts;
using Exam.Models;
using Exam.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {
        DataDbContext _db { get; set; }
        IWebHostEnvironment _environment;

        public HomeController(DataDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Fruits.Select(c => new FruitListItemVM
            {
                About = c.About,
                Name = c.Name,
                ImageUrl = c.ImageUrl
            }
            ).ToListAsync());
        }


    }
}