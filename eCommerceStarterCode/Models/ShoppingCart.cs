using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class ShoppingCart
    {

        public int ShoppingCartId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }


        
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }


    }
}
