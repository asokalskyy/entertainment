using System.Collections.Generic;
using System.Data.SqlClient;

namespace AtelierEntertainment
{
    /// <summary>
    /// ToDo: As we can guess data context is not important for current step, so just leaving it as it is. To be revised.
    /// </summary>
    public class OrderDataContext : IOrderDataContext
    {
        // ToDo: Move the constant to KeyVault store and init during resolving by IoC
        const string ConnectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password = myPassword;";


        /// <inheritdoc />
        public void CreateOrder(Order order)
        {
            var conn = new SqlConnection(ConnectionString);

            var cmd = conn.CreateCommand();

            cmd.CommandText = $"INSERT INTO dbo.Orders VALUES {order.Id}, {order.Customer.Id}, {order.Total}";

            cmd.ExecuteNonQuery();

            foreach (var item in order.Items)
            {
                cmd = conn.CreateCommand();

                cmd.CommandText = $"INSERT INTO dbo.OrderItems VALUES {order.Id}, {item.Code}, {item.Description}, {item.Price};";

                cmd.ExecuteNonQuery();
            }
        }

        /// <inheritdoc />
        public static Order LoadOrder(int id)
        {
            var conn = new SqlConnection(ConnectionString);

            var cmd = conn.CreateCommand();

            cmd.CommandText = $"SELECT * FROM dbo.Orders WHERE Id = {id}";

            var reader = cmd.ExecuteReader();

            var result = new Order { };

            result.Id = id;
            result.Total = reader.GetDecimal(2);

            return FillOrderLines(id, conn, result);
        }


        /// <inheritdoc />
        Order IOrderDataContext.LoadOrder(int id) => LoadOrder(id);

        /// <inheritdoc />
        public IEnumerable<Order> LoadOrdersByCustomerId(int customerId)
        {
            var conn = new SqlConnection(ConnectionString);

            var cmd = conn.CreateCommand();

            cmd.CommandText = $"SELECT * FROM dbo.Orders WHERE CustomerId = {customerId}";

            var reader = cmd.ExecuteReader();

            var orders = new List<Order>();

            while (reader.Read())
            {
                var order = new Order
                {
                    Id = reader.GetInt32(0),
                    Total = reader.GetDecimal(2)
                };

                FillOrderLines(order.Id, conn, order);

                orders.Add(order);
            }

            return orders;
        }



        private static Order FillOrderLines(int id, SqlConnection conn, Order result)
        {
            var cmd = conn.CreateCommand();

            cmd.CommandText = $"SELECT * FROM dbo.OrderItems WHERE OrderId = {id}";

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.Items.Add(new OrderItem { Code = reader.GetString(1), Description = reader.GetString(2), Price = reader.GetFloat(3) });
            }

            return result;
        }
    }
}