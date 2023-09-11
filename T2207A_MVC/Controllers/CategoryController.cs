using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2207A_MVC.Entities;
using T2207A_MVC.Models;

namespace T2207A_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context) // rejlection: 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            //ViewData["categories"] = categories;
            //ViewBag.Categories = categories;
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // khai bao giao thuc Post(Get khong phai khai bao)
        public IActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)// validate
            {
                _context.Categories.Add(new Category { name = model.name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(new CategoryEditModel { id=category.id, name=category.name });
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(new Category { id = model.id, name = model.name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
