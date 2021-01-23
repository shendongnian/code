    static void Main(String[] args)
    {
        Action write = null; // Action is a delegate type
        write += () => Console.WriteLine("one"); // first write
        write += () => Console.WriteLine("two"); // composition, looks quite easy compared to interfaces
        write(); // both delegates are executed ("one two")       
    }
