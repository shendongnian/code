    static void Main(string[] args)
    {
        var p = new Product()
            {
                ProductId = 1, 
                Name = "steve"
            }
            .FixProduct();
        System.Console.WriteLine(p.Name);
    }
