    static void Main(string[] args)
    {
        MyEnumerable<string> myEnumerable = new MyEnumerable<string>()
        {
            "First","Second","Fourth","Third"
        };
        foreach (var tmp in myEnumerable)
        {
            Console.WriteLine(tmp);
        }
    }
