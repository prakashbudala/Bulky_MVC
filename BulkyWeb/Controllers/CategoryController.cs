using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _db.Categories.ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
            //}
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index", "Category");
            }

            return View();

        }

        public IActionResult Edit(int? id)
        {
            if ( id == null || id == 0)
            {
                NotFound();
            }
            Category? categoryFromDB = _db.Categories.FirstOrDefault(c => c.Id == id);
            {
                
            }
            return View(categoryFromDB);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index", "Category");
            }

            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                NotFound();
            }
            Category? categoryFromDB = _db.Categories.FirstOrDefault(c => c.Id == id);
            {

            }
            return View(categoryFromDB);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully!";
                return RedirectToAction("Index", "Category");
            }

            return View();

        }
    }
}
