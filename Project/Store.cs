namespace Project;

public class Store
{
    public List<Product> Products { get; } = new List<Product>();

    public Store()
    {
        Products.Add(new Product(1, "iPhone 16 Pro Max", 5499.99m, 10));
        Products.Add(new Product(2, "MacBook Pro M4", 15999.99m, 5));
        Products.Add(new Product(3, "iPad Pro M2", 8499.99m, 7));
        Products.Add(new Product(4, "iMac 5K", 12899.99m, 3));
        Products.Add(new Product(5, "Air Pods Max", 3599.99m, 12));
        Products.Add(new Product(6, "Air Pods Pro usb-c", 1199.99m, 10));
        Products.Add(new Product(7, "Apple Display", 8999.99m, 4));
        Products.Add(new Product(8, "Apple Vision Pro", 12499.99m, 1));
        Products.Add(new Product(9, "Telewizor Samsung 55 cali", 3499.99m, 10));
        Products.Add(new Product(10, "Głośnik JBL Charge 5", 679.99m, 15));
    }

    public void DisplayProducts()
    {
        Console.WriteLine("=== DOSTĘPNE PRODUKTY ===");
        foreach (Product product in Products)
        {
            if (product.Stock > 0)
            {
                Console.WriteLine(product);
            }
        }
    }

    public Product GetProductById(int id)
    {
        return Products.Find(p => p.Id == id);
    }
}