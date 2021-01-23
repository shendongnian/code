    static void Main(string[] args)
    {
        // a new List has bee created with a set of integers
        List<int> numbers = new List<int>() { 2, 3, 4, 10, 12, 34 };
    
        // print the string to the Console:
        Console.WriteLine(string.Join(",", numbers.Where(x => x % 2 == 0)));
    }
