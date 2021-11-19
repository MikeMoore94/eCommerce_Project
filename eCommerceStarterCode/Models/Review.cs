namespace eCommerceStarterCode.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int CustomerId { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
    }
}
