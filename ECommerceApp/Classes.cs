using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp
{
    internal class Classes
    {
        static void CreateCustomer(string name, string email, string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        static int CreateOrder (int customerId, string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO ORDERS (CustomerId, OrderDate) OUTPUT INSERTED.OrderId VALUES (@CustomerId, @OrderDate)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    return (int)cmd.ExecuteScalar();    
                }
            }
        }
    }
}
