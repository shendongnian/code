    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        helper helper = new helper();
        helper.Process(c => Console.WriteLine("Main " + c.ToString()));            
        Console.ReadLine();
    }
