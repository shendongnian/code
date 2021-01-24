    static void Main(string[] args)
    {
        var input = "Hello, world!";
        var output = ToTriangle(input);
        foreach (var set in output)
        {
            Console.WriteLine(string.Join("",set));
        }
        Console.ReadLine();
    }
