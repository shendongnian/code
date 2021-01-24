    public static void Main(string[] args)
    {
        var host = new WebHostBuilder()
            .UseKestrel()
            .Build();                     //Modify the building per your needs
        host.Start();                     //Start server non-blocking
        //Regular console code
        while (true)
        {
            Console.WriteLine(Console.ReadLine());
        }
    }
