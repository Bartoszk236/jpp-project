namespace Project;

public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public CartItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public decimal TotalPrice()
    {
        return Product.Price * Quantity;
    }

    public override string ToString()
    {
        return "Product: " + Product + ", Quantity: " + Quantity;
    }
}