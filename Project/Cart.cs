namespace Project;

public class Cart
{
    private readonly Dictionary<int, CartItem> _items = new Dictionary<int, CartItem>();

    public void AddProduct(Product product, int quantity)
    {
        if (quantity <= 0) 
            throw new Exception("Ilość musi być większa od zera");
        if (product.Stock < quantity)
            throw new Exception("Taka ilość nie jest dostępna na stanie");
        if (_items.ContainsKey(product.Id))
        {
            var item = _items[product.Id];
            if (product.Stock < item.Quantity + quantity)
                throw new Exception("Taka ilość nie jest dostępna na stanie");
            item.Quantity += quantity;
        }
        else
        {
            _items.Add(product.Id, new CartItem(product, quantity));
        }
    }

    public void RemoveProduct(int id)
    {
        if (_items.ContainsKey(id))
            _items.Remove(id);
        else
            throw new KeyNotFoundException("Produktu nie ma w koszyku");
    }

    public void DisplayCart()
    {
        Console.WriteLine("=== TWÓJ KOSZYK ===");
        if (_items.Count == 0)
        {
            Console.WriteLine("Koszyk jest pusty");
            return;
        }

        foreach (var item in _items.Values)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Łącznie: " + this.getTotal());
    }

    public decimal getTotal()
    {
        decimal total = 0;
        foreach (var item in _items.Values)
            total += item.TotalPrice();
        return total;
    }
    
    public List<CartItem> getItems() => new List<CartItem>(_items.Values);
    
    public void Clear() => _items.Clear();
}