using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp
{
    class Program
    {
        static void Main()
        {
            /*Testprogram för att testa funktionaliteten i klasserna.
             * Skapar en kund, en order och lägger till orderrader.
             * Visar orderhistorik och beräknar totalbelopp för en order.
             * Använder en lokal SQL Server-databas.
             */
            try
            {
                // Connection string for local SQL Server database
                string connectionString = @"Server=(localdb)\mssqllocaldb;Database=ECommerceAppDb;Trusted_Connection=True;MultipleActiveResultSets=true";

                Classes.CreateCustomer("John Doe", "john@example.com", connectionString);

                int orderId = Classes.CreateOrder(1, connectionString);

                Classes.AddOrderRow(orderId, "Laptop", 1, 12000, connectionString);
                Classes.AddOrderRow(orderId, "Mouse", 2, 1500, connectionString);
                Classes.AddOrderRow(orderId, "Keyboard", 1, 3000, connectionString);
                Classes.AddOrderRow(orderId, "Monitor", 2, 8000, connectionString);

                Classes.ShowOrderHistory(1, connectionString);

                decimal total = Classes.CalculateOrderTotal(orderId, connectionString);
                Console.WriteLine($"Total Order Amount: {total}");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ReadLine();

            }
        }
    }

}
