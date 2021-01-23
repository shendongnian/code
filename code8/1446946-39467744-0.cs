    static void Main(string[] args)
    {
        //Displays the actual program in descending order.
        //Used functions as a faster method to change variable names on the fly
        //Whilst keeping its format clean and in descending order 
        Print("Name of Places", "EdwayApps", "Appxperts", "Genie App Studio", "Appster");
        Print("Name of Locations", "3/424 St kilda", "101/27 Little Collins St", "Contact Online only", "2/377 LonsDale ST");
        Print("Companies Numbers", 043990976, 1300939225, 0421336722, 1800709291);
        Console.ReadKey();
    }
    static void Print(string topic, params object[] array)
    {
        Console.WriteLine("-- {0} -- \n\n  {1}\n", topic, string.Join("\n  ", array));
    }
