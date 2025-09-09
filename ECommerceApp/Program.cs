using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            while (true)
            {
                string connectionString = @"Server=(localdb)\mssqllocaldb;Database=ECommerceAppDb;Trusted_Connection=True;MultipleActiveResultSets=true";
                Console.Clear();
                Console.WriteLine("E-Commerce Application Test Program");
                Console.WriteLine("1. Create Customer");
                Console.WriteLine("2. Create Order");
                Console.WriteLine("3. Add Order Row");
                Console.WriteLine("4. Show Order History");
                Console.WriteLine("5. Calculate Order Total");
                Console.WriteLine("Select an option (1-5):");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter customer name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter customer email:");
                        string email = Console.ReadLine();
                        Classes.CreateCustomer(name, email, connectionString);
                        Console.WriteLine($"Customer created successfully.");
                        break;
                    case "2":
                        Console.WriteLine("Enter customer ID:");
                        int customerId = int.Parse(Console.ReadLine());
                        int orderId = Classes.CreateOrder(customerId, connectionString);
                        Console.WriteLine($"Order created successfully with Order ID: {orderId}");
                        break;
                    case "3":
                        Console.WriteLine("Enter order ID:");
                        int ordId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter product name:");
                        string product = Console.ReadLine();
                        Console.WriteLine("Enter quantity:");
                        int quantity = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter price:");
                        decimal price = decimal.Parse(Console.ReadLine());
                        Classes.AddOrderRow(ordId, product, quantity, price, connectionString);
                        Console.WriteLine("Order row added successfully.");
                        break;
                    case "4":
                        Console.WriteLine("Enter customer ID to view order history:");
                        int custId = int.Parse(Console.ReadLine());
                        Classes.ShowOrderHistory(custId, connectionString);
                        break;
                    case "5":
                        Console.WriteLine("Enter order ID to calculate total:");
                        int oId = int.Parse(Console.ReadLine());
                        decimal total = Classes.CalculateOrderTotal(oId, connectionString);
                        Console.WriteLine($"Total Order Amount: {total}");
                        break;
                    default:
                        Console.WriteLine("Invalid option selected.");
                        break;
                }


                //try
                //{
                //    // Connection string for local SQL Server database
                //    string connectionString = @"Server=(localdb)\mssqllocaldb;Database=ECommerceAppDb;Trusted_Connection=True;MultipleActiveResultSets=true";

                //    Classes.CreateCustomer("John Doe", "john@example.com", connectionString);

                //    int orderId = Classes.CreateOrder(1, connectionString);

                //    Classes.AddOrderRow(orderId, "Laptop", 1, 12000, connectionString);
                //    Classes.AddOrderRow(orderId, "Mouse", 2, 1500, connectionString);
                //    Classes.AddOrderRow(orderId, "Keyboard", 1, 3000, connectionString);
                //    Classes.AddOrderRow(orderId, "Monitor", 2, 8000, connectionString);

                //    Classes.ShowOrderHistory(1, connectionString);

                //    decimal total = Classes.CalculateOrderTotal(orderId, connectionString);
                //    Console.WriteLine($"Total Order Amount: {total}");
                //    Console.ReadLine();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"An error occurred: {ex.Message}");
                //    Console.ReadLine();

                //}
            }
        }

    }
}
