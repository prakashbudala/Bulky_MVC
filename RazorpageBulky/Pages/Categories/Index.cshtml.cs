using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorpageBulky.Data;
using RazorpageBulky.Models;


namespace RazorpageBulky.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
