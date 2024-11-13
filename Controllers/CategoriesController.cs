using Microsoft.AspNetCore.Mvc;
using MyRestaurantApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // In-memory category list
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Beverages" },
            new Category { Id = 2, Name = "Main Dishes" }
        };

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return categories;
        }

        // GET: api/Categories/1
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        // POST: api/Categories
        [HttpPost]
        public ActionResult<Category> CreateCategory(Category category)
        {
            category.Id = categories.Count > 0 ? categories.Max(c => c.Id) + 1 : 1;
            categories.Add(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // PUT: api/Categories/1
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Category updatedCategory)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            category.Name = updatedCategory.Name;
            return NoContent();
        }

        // DELETE: api/Categories/1
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            categories.Remove(category);
            return NoContent();
        }
    }
}
