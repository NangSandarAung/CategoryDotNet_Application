using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListApplication.Data;
using BookListApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookListApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BookListDbContext _db;

        public CategoryController(BookListDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categorylist =  _db.Categories;
            return View(categorylist);
        }

        //GET - CRETAENEW
        public IActionResult CreateNew()
        {
            return View();
        }

        //POST - CREATENEW
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNew(Category catObj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(catObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catObj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Categories.Find(id);

            if( obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                //update will only work if there is Id
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Categories.Find(id);
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
