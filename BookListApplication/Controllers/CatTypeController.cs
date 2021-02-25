using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListApplication.Data;
using BookListApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookListApplication.Controllers
{
    public class CatTypeController : Controller
    {
        private readonly BookListDbContext _db;

        public CatTypeController(BookListDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<CatType> catTypeList = _db.CatTypes;
            return View(catTypeList);
        }

        public IActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNew(CatType obj)
        {
            if (ModelState.IsValid)
            {
                _db.CatTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.CatTypes.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(CatType obj)
        {
            if (ModelState.IsValid)
            {
                _db.CatTypes.Update(obj);
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

            var obj = _db.CatTypes.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(CatType obj)
        {
            if (ModelState.IsValid)
            {
                _db.CatTypes.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
