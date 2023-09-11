using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2207A_MVC.Entities;
using T2207A_MVC.Models.Product;

namespace T2207A_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;

        public ProductController(DataContext context) // rejlection: 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.Include(p => p.category).Include(p => p.brand).ToList();
            // Where(p=>p.name.Equals("Samsung")) : baif toasn timf kiem
            // Where(p=>p.name.Contains("Samsung")) || p.name.Contains : timf kiem nhung sp co ten la samsung iphone
            // Take(10) : lay 10 sp
            // Skip(10) : bo 10 sp
            // OrderBy(p=>p.name) : asc
            // OrderByDescending(p=>p.name) : desc
            return View(products);
        }

        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            var brands = _context.Brands.ToList();

            ViewBag.Categories = categories;
            ViewBag.Brands = brands;

            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(new Product { 
                    name = model.name, 
                    price = model.price, 
                    description = model.description, 
                    category_id = model.category_id, 
                    brand_id = model.brand_id
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var categories = _context.Categories.ToList();
            var brands = _context.Brands.ToList();

            ViewBag.Categories = categories;
            ViewBag.Brands = brands;

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var categories = _context.Categories.ToList();
            var brands = _context.Brands.ToList();

            ViewBag.Categories = categories;
            ViewBag.Brands = brands;

            return View(new ProductEditModel 
            { 
                id = product.id, 
                name = product.name, 
                price = product.price, 
                description = product.description, 
                category_id = product.category_id, 
                brand_id = product.brand_id
            });
        }
        [HttpPost]
        public IActionResult Edit(ProductEditModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(new Product
                {
                    id = model.id,
                    name = model.name,
                    price = model.price,
                    description = model.description,
                    category_id = model.category_id,
                    brand_id = model.brand_id
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var categories = _context.Categories.ToList();
            var brands = _context.Brands.ToList();

            ViewBag.Categories = categories;
            ViewBag.Brands = brands;

            return View(model);
        }

        public  IActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Upload()
        {
            return View();
        }
    }
}
