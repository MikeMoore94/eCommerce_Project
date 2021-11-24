using System.Linq;
using System.Security.Claims;
using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/shoppingcart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET 
        [HttpGet]
        public IActionResult GetAll()
        {
            var shoppingCart = _context.ShoppingCarts
                .ToList();

            if (shoppingCart == null)
            {
                return NotFound();
            }
            return Ok(shoppingCart);
        }

        // GET 
        [HttpGet("{userId}")]
        public IActionResult Get(string userId)
        {
            var shoppingCart = _context.ShoppingCarts
                .Where(sc => sc.UserId == userId)
                .Include(sc => sc.Product)
                .Select(sc => new {
                    sc.UserId,
                    sc.ProductId,
                    sc.Product.Name,
                    sc.Product.Description,
                    sc.Quantity,
                    sc.Product.Price,
                    ItemSubtotal = sc.Quantity * sc.Product.Price
                })
                .ToList();

            if (shoppingCart == null)
            {
                return NotFound();
            }
            return Ok(shoppingCart);
        }

        // POST 
        [HttpPost]
        public IActionResult Post([FromBody] ShoppingCart value)
        {

            _context.ShoppingCarts.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // DELETE 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var shoppingCart = _context.ShoppingCarts.FirstOrDefault(sc => sc.ShoppingCartId == id);
            _context.Remove(shoppingCart);
            _context.SaveChanges();
            return Ok();
        }
        
    }
}