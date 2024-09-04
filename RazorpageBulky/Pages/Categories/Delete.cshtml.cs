using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorpageBulky.Data;
using RazorpageBulky.Models;

namespace RazorpageBulky.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public Category Category { get; set; }
        public DeleteModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            Category? obj = _db.Categories.Find(Category.Id);


            if (obj.Id == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted successfully!";
            return RedirectToPage("Index");
        }
    }
}

