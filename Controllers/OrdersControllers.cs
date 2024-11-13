using Microsoft.AspNetCore.Mvc;
using MyRestaurantApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // In-memory order list
        private static List<Order> orders = new List<Order>();

        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return orders;
        }

        // GET: api/Orders/1
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // POST: api/Orders
        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            order.Id = orders.Count > 0 ? orders.Max(o => o.Id) + 1 : 1;
            order.Status = "ORDER"; // Default status
            orders.Add(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // PUT: api/Orders/1
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, Order updatedOrder)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            order.TableId = updatedOrder.TableId;
            order.Products = updatedOrder.Products;
            order.Status = updatedOrder.Status;
            return NoContent();
        }

        // DELETE: api/Orders/1
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            orders.Remove(order);
            return NoContent();
        }

        // PATCH: api/Orders/1/status
        [HttpPatch("{id}/status")]
        public IActionResult UpdateOrderStatus(int id, [FromBody] string status)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            order.Status = status;
            return NoContent();
        }
    }
}
