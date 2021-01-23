    HashSet<string> months = new HashSet<string>(StringComparer.OrdinalIgnoreCase)            
    {
        "January" ,"February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    };
    Console.Write("\nWhat month will this event be taking place? ");
    string sMonth = Console.ReadLine();
    while (!months.Contains(sMonth))
    {
        Console.WriteLine("The month was invalid, retry ...");
        sMonth = Console.ReadLine();
    }
    Console.WriteLine("Valid ... lets do other stuff");
