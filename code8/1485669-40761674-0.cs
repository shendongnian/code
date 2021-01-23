    static void Main(string[] args)
    {
        Console.WriteLine("Write a list of Words");
        string input = Console.ReadLine();
        List<string> words = input.Split(' ').ToList();
        List<string> result = new List<string>();
        bool match = false;
