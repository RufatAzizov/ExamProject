﻿using Exam.Contexts;
using Exam.Models;
using Exam.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class FruitsController : Controller
    {
        DataDbContext _db { get; set; }
        IWebHostEnvironment _environment;

        public FruitsController(DataDbContext db, IWebHostEnvironment environment)
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
                Id = c.Id,
                ImageUrl = c.ImageUrl
            }
            ).ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Cancel()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Create(FruitCreateVM vm)
        {
           if (!ModelState.IsValid)
            {
                return View(vm);
            }
            string filename = null;
            if (vm.FileImage != null) 
            {
                filename = Guid.NewGuid() + Path.GetExtension(vm.FileImage.FileName);
                using (Stream fs = new FileStream(Path.Combine(_environment.WebRootPath, "assets", "CreatedImages", filename), FileMode.Create))
                {
                    await vm.FileImage.CopyToAsync(fs);
                };   
            }
            Fruit fruit = new Fruit
            {
                Name = vm.Name,
                About = vm.About,
                ImageUrl = filename
            };
            await _db.Fruits.AddAsync(fruit);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Fruits.FindAsync(id);
            if (data == null) return NotFound();
            return View(new FruitUpdateVM
            {
                ImageUrl = data.ImageUrl,
                Id = data.Id,
                About = data.About,
                Name = data.Name,
            });
            
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, FruitUpdateVM vm)
        {
            if (id == null) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var data = await _db.Fruits.FindAsync(id);
            if (data == null) return NotFound();
            data.About = vm.About;
            data.Id = vm.Id;
            data.Name = vm.Name;


            string filepath = Path.Combine(_environment.WebRootPath, "Assets", "CreatedImages", data.ImageUrl);
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
            
            string filename = Guid.NewGuid() + Path.GetExtension(vm.FileImage.FileName);

            filename = Guid.NewGuid() + Path.GetExtension(vm.FileImage.FileName);
            using (Stream fs = new FileStream(Path.Combine(_environment.WebRootPath, "assets", "CreatedImages", filename), FileMode.Create))
            {
                await vm.FileImage.CopyToAsync(fs);
            };
            data.ImageUrl = filename;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Fruits.FindAsync(id);
            if (data == null) return NotFound();
            _db.Remove(data);   
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
