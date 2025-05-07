namespace Project;

public class Program
{
    static void Main(string[] args)
    {
        Store store = new Store();
        Cart cart = new Cart();
        bool run = true;

        while (run)
        {
            Console.WriteLine("\n=== SKLEP ===");
            Console.WriteLine("1. Wyświetl produkty");
            Console.WriteLine("2. Dodaj produkt do koszyka");
            Console.WriteLine("3. Usuń produkt z koszyka");
            Console.WriteLine("4. Pokaż koszyk");
            Console.WriteLine("5. Finalizuj zakup");
            Console.WriteLine("0. Wyjdź");
            Console.Write("Wybierz opcję: ");
            
            var input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    store.DisplayProducts();
                    break;
                case "2":
                    try
                    {
                        Console.Write("Podaj Id produktu: ");
                        int idToAdd = int.Parse(Console.ReadLine() ?? "");
                        Console.Write("Podaj ilość: ");
                        int quantityToAdd = int.Parse(Console.ReadLine() ?? "");

                        var productToAdd = store.GetProductById(idToAdd);
                        if (productToAdd == null)
                        {
                            Console.WriteLine("Nie znaleziono produktu");
                            break;
                        }

                        cart.AddProduct(productToAdd, quantityToAdd);
                        Console.WriteLine("Produkt dodany do koszyka");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Błąd: " + ex.Message);
                    }
                    break;
                case "3":
                    try
                    {
                        Console.Write("Podaj Id produktu do usunięcia: ");
                        int idToRemove = int.Parse(Console.ReadLine() ?? "");
                        cart.RemoveProduct(idToRemove);
                        Console.WriteLine("Produkt usunięty z koszyka");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Błąd: " + ex.Message);
                    }
                    break;
                case "4":
                    cart.DisplayCart();
                    break;
                case "5":
                    if (cart.getItems().Count == 0)
                    {
                        Console.WriteLine("Koszyk jest pusty");
                        break;
                    }
                    
                    Console.WriteLine("=== PODSUMOWANIE ZAKUPU ===");
                    cart.DisplayCart();
                    Console.WriteLine("Potwierdzić zamówienie? (t/n): ");
                    var confirm = Console.ReadLine();
                    if (confirm?.ToLower() == "t")
                    {
                        foreach (var item in cart.getItems())
                        {
                            item.Product.Stock -= item.Quantity;
                        }
                        Console.WriteLine("Zakup zrealizowany");
                        cart.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Zakup anulowany");
                    }
                    break;
                case "0":
                    run = false;
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja");
                    break;
            }
        }
    }
}