    static void Main(string[] args)
    {
        string[] name= {"Bob","Bob2","Bob3","Bob4"};
        
        string userName = Console.ReadLine();
        bool exists = name.Contains(userName);
        if (exists == true)
            Console.WriteLine("Hi " + userName);
        Console.ReadLine();
    }
