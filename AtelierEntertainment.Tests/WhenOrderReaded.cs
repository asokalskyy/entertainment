using AtelierEntertainment.Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AtelierEntertainment.Tests
{
    public class WhenOrderReaded : OrderTestBase
    {
        [Fact]
        public void ShouldFilterById()
        {
            var orderService = new OrderService(new OrderDataContextFake(PrepareDemoData()));

            var result = orderService.ViewOrder(5);

            Assert.True(result.Id == 5);
        }

        [Fact]
        public void ShouldThrowExceptionOnNotFoundById()
        {
            var orderService = new OrderService(new OrderDataContextFake(PrepareDemoData()));

            Assert.Throws<InvalidOperationException>(()=>orderService.ViewOrder(50));
        }

        [Fact]
        public void ShouldFilterByCustomer1()
        {
            var orderService = new OrderService(new OrderDataContextFake(PrepareDemoData()));

            var result = orderService.ViewOrdersByCustomer(1);

            Assert.True(result.All(order => order.Customer.Id == 1));
        }

        private static List<Order> PrepareDemoData() {
            var orders = new List<Order>();

            for (int i = 0; i < 20; i++)
            {
                var customer = i % 2 == 0 
                    ? new Customer { Id = 1, Country = "AU" }
                    : new Customer { Id = 2, Country = "UK" };

                orders.Add(CreateTestOrder(i, customer));
            }

            return orders;
        }
    }
}
