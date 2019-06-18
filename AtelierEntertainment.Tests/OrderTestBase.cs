using System.Collections.Generic;

namespace AtelierEntertainment.Tests
{
    public class OrderTestBase
    {
        /// <summary>
        /// Create Test Order
        /// </summary>
        /// <param name="id">Order identifier</param>
        /// <param name="customer">Customer</param>
        /// <returns></returns>
        protected static Order CreateTestOrder(int id, Customer customer)
        {
            var orderItem = new OrderItem
            {
                Code = "testCode",
                Description = "testDescription",
                Price = 1
            };

            var order = new Order
            {
                Id = id,
                Customer = customer,
                Items = new List<OrderItem> { orderItem }
            };

            return order;
        }
    }
}
