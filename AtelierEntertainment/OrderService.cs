using System;
using System.Collections.Generic;
using System.Linq;

namespace AtelierEntertainment
{
    public class OrderService
    {
        IOrderDataContext _context;

        public OrderService(IOrderDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// ToDo: Move the calculation logic to Order
        /// </summary>
        /// <param name="order"></param>
        public void CreateOrder(Order order)
        {
            if (order.Customer.Country == "AU")
                order.Total = Convert.ToDecimal(order.Items.Sum(_ => _.Price) * 1.1);
            else if (order.Customer.Country == "UK")
                order.Total = Convert.ToDecimal(order.Items.Sum(_ => _.Price) * 1.2);

            _context.CreateOrder(order);
        }

        /// <summary>
        /// Gets the single order by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order ViewOrder(int id) => _context.LoadOrder(id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public IReadOnlyCollection<Order> ViewOrdersByCustomer(int customerId) =>
            _context.LoadOrdersByCustomerId(customerId).ToList();
    }
}
