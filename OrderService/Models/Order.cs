using OrderService.Models;

namespace OrderService.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string? Status { get; set; }
        public DateTime Created { get; set; }
        public List<Item> Lines { get; set; } = new();
    }
}
