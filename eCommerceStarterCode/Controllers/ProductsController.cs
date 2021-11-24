using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace eCommerceStarterCode.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET ALL
        [HttpGet]
        public IActionResult Get()
        {
            var products = _context.Products;
            return Ok(products);
        }
        // GET
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var merch = _context.Products.Find(id);
            if (merch == null)
            {
                return NotFound();
            }
            return Ok(merch);
        }
        // POST 
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            _context.Products.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }
    }
}