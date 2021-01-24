    static void Main(string[] args)
    {
        string myString = "bhargav m patel".Trim();
        Console.Write("Type a char : ");
        string mychar = Console.ReadLine();
        if (myString.StartsWith(mychar))
            Console.WriteLine("true");
        else 
           Console.WriteLine("false");
               
        Console.ReadLine();
    }
