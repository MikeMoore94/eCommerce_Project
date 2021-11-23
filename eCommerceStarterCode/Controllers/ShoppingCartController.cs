using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("shoppingCart")]

        public IActionResult GetCart()
        {
            //everthing that is currently in the cart
            var cart = _context.ShoppingCarts.ToList();
            return Ok(cart);
        }

        [HttpGet("shoppingCart/{userid}")]

        public IActionResult GetMyCart(string userid)
        {
            //everthing that is currently in the cart
            var cart = _context.ShoppingCarts.Where(u => u.UserId == userid);
            return Ok(cart);
        }

        [HttpDelete("shoppingCart/{userid}/delete/{Id}")]

        public IActionResult DeleteItem(string userid, int Id)
        {

            var productToDelete = _context.ShoppingCarts
                .Where(u => u.UserId == userid && u.ProductId == Id)
                .SingleOrDefault();

            if (productToDelete == null)
            {
                return NotFound($"Product = {Id} not found");
            }
            _context.ShoppingCarts.Remove(productToDelete);
            _context.SaveChanges();
            return StatusCode(200, productToDelete);
        }
        [HttpDelete("shoppingCart/delete/{cartId}")]

        public IActionResult DelectProduct(int Id)
        {

            var productToDelete = _context.ShoppingCarts
                .Where(u => u.CartId == Id)
                .SingleOrDefault();

            if (productToDelete == null)
            {
                return NotFound($"book with BookId = {Id} not found");
            }
            _context.ShoppingCarts.Remove(productToDelete);
            _context.SaveChanges();
            return StatusCode(200, productToDelete);
        }

        [HttpPost("shoppingCart/addProduct/")]

        public IActionResult AddProduct([FromBody] ShoppingCart value)
        {
            _context.ShoppingCarts.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        [HttpPut("shoppingCart/update/{userId}/{Id:int}")]

        public IActionResult UpdateCart(string userId, int Id, [FromBody] ShoppingCart value)
        {
            var cart = _context.ShoppingCarts.Where(u => u.UserId == userId && u.ProductId == Id).SingleOrDefault();
            if (cart == null)
            {
                return NotFound("No shopping cart that meets that criteria");
            }

            cart.Quantity = value.Quantity;

            _context.ShoppingCarts.Update(cart);
            _context.SaveChanges();
            return StatusCode(201, value);
        }
    }

}