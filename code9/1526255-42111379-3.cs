    static void Main(string[] args)
    {
        // It's the Model that should take case into account
        string product = Console.ReadLine();
        string city = Console.ReadLine();
        double amount = double.Parse(Console.ReadLine());
        Dictionary<string, double> products = null;
        double price;
        if (!s_Model.TryGetValue(city, out products)) 
          Console.WriteLine("Incorrect city"); 
        else if (products.TryGetValue(products, out price))
          Console.WriteLine("Incorrect product");
        else
          Console.Write((amount * price).ToString("F2"));
    }  
