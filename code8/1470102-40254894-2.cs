    static void Main(string[] args)
    {
        Timer timer = new System.Threading.Timer((e) =>
        {
            Console.WriteLine("Now the following code will be repeated over and over");
        }, null, 0, (int)TimeSpan.FromSeconds(5).TotalMilliseconds);
        Console.Read();
    }
