using Bulky.Razor.Temp.Data;
using Bulky.Razor.Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky.Razor.Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Category? Category { get; set; }

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                Category = _context.Categories.FirstOrDefault(x => x.Id == id);
            }


        }
        public IActionResult OnPost()
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == Category.Id);
            if (category == null)
            {
                return NotFound();
            }


            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");



        }
    }
}
