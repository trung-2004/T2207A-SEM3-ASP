using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2207A_MVC.Entities;
using T2207A_MVC.Models;

namespace T2207A_MVC.Controllers
{
    public class BrandController : Controller
    {

        private readonly DataContext _context;

        public BrandController(DataContext context) // rejlection: 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var brands = _context.Brands.ToList();
            return View(brands);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BrandViewModel model)
        {
            if (ModelState.IsValid)// validate
            {
                _context.Brands.Add(new Brand { name = model.name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(new BrandEditModel { id = brand.id, name = brand.name });
        }

        [HttpPost]
        public IActionResult Edit(BrandEditModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Brands.Update(new Brand { id = model.id, name = model.name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Brand brand = _context.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }
            _context.Brands.Remove(brand);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
