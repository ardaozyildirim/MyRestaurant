namespace MyRestaurantApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public string Status { get; set; } // "ORDER", "CANCELLED", "COMPLETED"
    }
}
