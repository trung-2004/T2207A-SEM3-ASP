using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2207A_MVC.Entities;

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

        public IActionResult Edit()
        {
            return View();
        }
    }
}
