using System.Collections.Generic;

namespace AtelierEntertainment
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal Total { get; internal set; }
    }
}