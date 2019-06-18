using AtelierEntertainment.Tests.Fakes;
using System;
using Xunit;

namespace AtelierEntertainment.Tests
{
    public class WhenOrderCreated : OrderTestBase
    {
        [Fact]
        public void ShouldCalcPointOneTotalForAUCustomer()
        {
            var order = CreateTestOrder(1, new Customer
            {
                Id = 1,
                Country = "AU"
            });
            var orderService = new OrderService(new OrderDataContextFake());

            orderService.CreateOrder(order);

            var result = orderService.ViewOrder(order.Id);
            Assert.True(result.Total == 1.1m);
        }

        [Fact]
        public void ShouldCalcPointTwoTotalForUKCustomer()
        {
            var order = CreateTestOrder(1, new Customer
            {
                Id = 1,
                Country = "UK"
            });

            var orderService = new OrderService(new OrderDataContextFake());

            orderService.CreateOrder(order);

            var result = orderService.ViewOrder(order.Id);
            Assert.True(result.Total == 1.2m);
        }

        [Fact]
        public void ShouldThrowAnExceptionForNullCustomer()
        {
            var order = CreateTestOrder(1, null);

            var orderService = new OrderService(new OrderDataContextFake());

            Assert.Throws<NullReferenceException>(() => orderService.CreateOrder(order));
        }
    }
}
