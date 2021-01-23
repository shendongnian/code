    static void Main(String[] args)
    {
        Action write = null; // Action is a delegate type
        write += () => Console.WriteLine("one"); // composition
        write += () => Console.WriteLine("two"); // composition, looks quite easy
        write(); // both delegates are executed ("one two")       
    }
