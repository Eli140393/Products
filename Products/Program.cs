using System;
using Products.Entities;
using System.Globalization;
using Products.Entities.Enums;
namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date(DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Client c1 = new Client(name, email, date);

            Console.WriteLine("----------------------");

            Console.WriteLine("Enter order data");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(DateTime.Now, status, c1);
            
            Console.Write("How many items to this order ? : ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");

                string nameProduct = Console.ReadLine();
                Console.Write("Product price: ");
                double PriceProduct = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(nameProduct, PriceProduct);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                OrderItem item = new OrderItem(quantity, PriceProduct, product);

                order.AddItems(item);
            }

            Console.WriteLine("ORDER SUMMARY: ");
            Console.WriteLine(order);

      
      

        }
    }
}
