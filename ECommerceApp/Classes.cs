using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp
{
    class Classes
    {
        public static void CreateCustomer(string name, string email, string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Customer (Name, Email) VALUES (@Name, @Email)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static int CreateOrder(int customerId, string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Orders (CustomerId, OrderDate) OUTPUT INSERTED.Id VALUES (@CustomerId, @OrderDate)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        public static void AddOrderRow(int orderId, string product, int quantity, decimal price, string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO OrderRow (OrderId, Product, Quantity, Price) VALUES (@OrderId, @Product, @Quantity, @Price)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    cmd.Parameters.AddWithValue("@Product", product);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void ShowOrderHistory(int customerId, string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT o.Id, o.OrderDate, r.Product, r.Quantity, r.Price
                               FROM Orders o
                                JOIN OrderRow r ON o.Id = r.OrderId
                                 WHERE o.CustomerId = @CustomerId";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"OrderId: {reader["Id"]}, Date: {reader["OrderDate"]}, " +
                                              $"Product: {reader["Product"]}, Qty: {reader["Quantity"]}, Price: {reader["Price"]}");
                        }
                    }
                }
            }
        }
        public static decimal CalculateOrderTotal(int orderId, string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT SUM(Quantity * Price) FROM OrderRow WHERE OrderId = @OrderId";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
                }
            }
        }
    }
}
