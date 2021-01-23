    static void Main(string[] args)
    {
        Console.Write("Enter a number:");
        int num = int.Parse(Console.ReadLine());
        
        var numbers = Enumerable.Range(1, num);
        var allNumbers = string.Join(" ", numbers);
        Console.WriteLine(allNumbers);
        Console.WriteLine("Sum = {0}", numbers.Sum())
    }
