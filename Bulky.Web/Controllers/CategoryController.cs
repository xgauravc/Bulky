
using Bulky.DataAccess;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = _context.Categories.ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category) {
            //if (category.Name== category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "Display Order and Name field can't be same");
            //}

            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["success"] = "Category created successfully";

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            var category2 = _context.Categories.Find(id); // works for PK
            var category3 = _context.Categories.Where(c => c.Id == id).FirstOrDefault();

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
          

            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["success"] = "Category updated successfully";


                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            var category2 = _context.Categories.Find(id); // works for PK
            var category3 = _context.Categories.Where(c => c.Id == id).FirstOrDefault();

            return View(category);
        }
        [HttpPost,ActionName("Delete")]

        public IActionResult DeletePost(int? id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            
                
            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";


            return RedirectToAction("Index");
           
        }

    }
}
