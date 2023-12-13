using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Product
{
    public string Name { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public decimal ComputePrice()
    {
        return Price * Quantity;
    }
}

public class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }
}

public class Address
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string Country { get; set; }

    public bool IsInUSA()
    {
        return Country == "USA";
    }

    public override string ToString()
    {
        return $"{StreetAddress}\n{City}, {StateProvince}\n{Country}";
    }
}

public class Order
{
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = Products.Sum(p => p.ComputePrice());
        totalCost += Customer.IsInUSA() ? 5 : 35;
        return totalCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var product in Products)
        {
            sb.AppendLine($"{product.Name} ({product.ProductId})");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{Customer.Name}\n{Customer.Address}";
    }
}

public class Program
{
    public static void Main()
    {
        var order1 = new Order
        {
            Products = new List<Product>
            {
                new Product { Name = "Shoes", ProductId = 1, Price = 10.0m, Quantity = 2 },
                new Product { Name = "Caps", ProductId = 2, Price = 23.0m, Quantity = 3 }
            },
            Customer = new Customer
            {
                Name = "Julian",
                Address = new Address
                {
                    StreetAddress = "123 Main St",
                    City = "Fox",
                    StateProvince = "CA",
                    Country = "USA"
                }
            }
        };

        var order2 = new Order
        {
            Products = new List<Product>
            {
                new Product { Name = "Xbox", ProductId = 3, Price = 30.0m, Quantity = 4 },
                new Product { Name = "Playstation 4", ProductId = 4, Price = 45.0m, Quantity = 5 },
                new Product { Name = "Cams", ProductId = 5, Price = 50.0m, Quantity = 6 }
            },
            Customer = new Customer
            {
                Name = "Brayan",
                Address = new Address
                {
                    StreetAddress = "456 Elm St",
                    City = "nanana",
                    StateProvince = "NY",
                    Country = "Canada"
                }
            }
        };

        var orders = new List<Order> { order1, order2 };

        foreach (var order in orders)
        {
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());

            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());

            Console.WriteLine("Total Price: ${0}", order.CalculateTotalCost());

            Console.WriteLine();
        }
    }
}
