using Microsoft.AspNetCore.Mvc;
using MVCProductCategory.Models;
using System.Linq;

namespace MVCProductCategory.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        // Constructor injects the database context
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Show all categories
        public IActionResult Index()
        {
            var categories = _db.Categories.ToList();
            return View(categories);
        }

        // Show form to create a new category
        public IActionResult Create()
        {
            return View();
        }

        // Save new category to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category); // Add to database
                _db.SaveChanges(); // Save changes
                return RedirectToAction(nameof(Index)); // Go back to list
            }
            return View(category); // Return form if validation fails
        }

        // Show form to edit category
        public IActionResult Edit(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null) return NotFound();
            return View(category);
        }

        // Save edited category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // Show delete confirmation
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null) return NotFound();
            return View(category);
        }

        // Delete category
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _db.Categories.Find(id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
