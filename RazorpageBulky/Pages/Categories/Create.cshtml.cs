using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorpageBulky.Data;
using RazorpageBulky.Models;

namespace RazorpageBulky.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public Category Category { get; set; }
        public CreateModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _db.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Category Created successfully!";

            return RedirectToPage("Index");
        }
    }
}
