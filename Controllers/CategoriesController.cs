using Microsoft.AspNetCore.Mvc;
using MyRestaurant.Busınnes.Services.Abstract;
using MyRestaurantApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyRestaurantApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryServıce;

        public CategoriesController(ICategoryService categoryServıce)
        {
            this.categoryServıce = categoryServıce;
        }

        List<Category> categories = new();
  
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
            category = categoryServıce.Save(category);
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
