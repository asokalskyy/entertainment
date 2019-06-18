using System.Collections.Generic;
using System.Linq;

namespace AtelierEntertainment.Tests.Fakes
{
    public class OrderDataContextFake : IOrderDataContext
    {
        private List<Order> Context { get; } = new List<Order>();

        public OrderDataContextFake()
        {
            Context = new List<Order>();
        }

        public OrderDataContextFake(List<Order> orders)
        {
            Context = orders;
        }

        public void CreateOrder(Order order)
        {
            Context.Add(order);
        }

        public Order LoadOrder(int id)
        {
            return Context.Single(o => o.Id == id);
        }

        public IEnumerable<Order> LoadOrdersByCustomerId(int customerId)
        {
            return Context.Where(o => o.Customer.Id == customerId);
        }
    }
}
