using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace eCommerceStarterCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var reviews = _context.Reviews.Include(r => r.Product).Include(r => r.User).Where(review => review.ProductId == id);
            return Ok(reviews);
        }



        // POST 
        [HttpPost]
        public IActionResult Post([FromBody] Review value)
        {
            _context.Reviews.Add(value);
            var product = _context.Products.FirstOrDefault(product => product.ProductId == value.ProductId);
            _context.SaveChanges();
            return Ok(value);
        }
        // PUT 
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review value)
        {
            var review = _context.Reviews.FirstOrDefault(review => review.ReviewId == id);
            review.Description = value.Description;
            review.Rating = value.Rating;
            review.UserId = value.UserId;
            _context.SaveChanges();
            return Ok(review);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var review = _context.Reviews.FirstOrDefault(review => review.ReviewId == id);
            _context.Remove(review);
            _context.SaveChanges();
            return Ok();
        }
    }
}
