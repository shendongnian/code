    public static void Main(string[] args)
    {
 
        ConsOut = Console.Out;  //Save the reference to the old out value (The terminal)
        Console.SetOut(new StreamWriter(Stream.Null)); //Remove console output
        var host = new WebHostBuilder()
            .UseKestrel()
            .Build();                     //Modify the building per your needs
        host.Start();                     //Start server non-blocking
        Console.SetOut(ConsOut);          //Restore output
        //Regular console code
        while (true)
        {
            Console.WriteLine(Console.ReadLine());
        }
    }
