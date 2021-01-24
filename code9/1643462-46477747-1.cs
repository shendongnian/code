    static void Main(string[] args)
    {
        var input = "1.2 3.4 5.6 7.8 9";
        var numbers = input.Split().Select(s => decimal.Parse(s));
        var beforeDots = numbers.Select(n => (int)Math.Truncate(n));
        var afterDots = numbers.Select(n => (int)((n - Math.Truncate(n)) * 10));
        
        Console.WriteLine(string.Join(",", beforeDots));
        Console.WriteLine(string.Join(",", afterDots));
        Console.ReadLine();
    }
    
    // Output:
    // 1,3,5,7,9
    // 2,4,6,8,0
