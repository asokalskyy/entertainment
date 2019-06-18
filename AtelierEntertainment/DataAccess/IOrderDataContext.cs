using System.Collections.Generic;

namespace AtelierEntertainment
{
    public interface IOrderDataContext
    {
        /// <summary>
        /// Creates an order
        /// </summary>
        /// <param name="id">Order identifier</param>
        /// <returns></returns>
        void CreateOrder(Order order);

        /// <summary>
        /// Gets a single order by ID
        /// </summary>
        /// <param name="id">Order identifier</param>
        /// <returns></returns>
        Order LoadOrder(int id);

        /// <summary>
        /// Gets all orders by CustomerId
        /// </summary>
        /// <param name="id">Order identifier</param>
        /// <returns></returns>
        IEnumerable<Order> LoadOrdersByCustomerId(int customerId);
    }
}