using System;
using System.Collections.Generic;

public class Product
{
    private string name;
    private string productID;
    private double price;
    private int quantity;

    public Product(string name, string productID, double price, int quantity)
    {
        this.name = name;
        this.productID = productID;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetPackingLabel()
    {
        return $"Product: {name}, ID: {productID}";
    }
}

public class Address
{
    private string streetAddress;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{streetAddress}\n{city}, {stateOrProvince}\n{country}";
    }
}

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }

    public string GetShippingLabel()
    {
        return $"Customer: {name}\nAddress:\n{address.GetFullAddress()}";
    }
}

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public double CalculateTotalCost()
    {
        double total = 0;
        foreach (Product product in products)
        {
            total += product.GetTotalCost();
        }

        if (customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (Product product in products)
        {
            packingLabel += product.GetPackingLabel() + "\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + customer.GetShippingLabel();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Product product1 = new Product("Laptop", "001", 999.99, 1);
        Product product2 = new Product("Pepsi", "002", 19.99, 2);
        Address address = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer = new Customer("Ojukwu Obinna", address);
        List<Product> products = new List<Product> { product1, product2 };
        Order order = new Order(products, customer);
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.CalculateTotalCost()}");
    }
}