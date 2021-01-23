    const string pass = "Password";            
    string attempt;
    
    for(int i=0;i<3;i++)
    {
        Console.Write("Please enter password: ");
        attempt = Console.ReadLine();
    
        if (attempt == pass)
        {
            Console.WriteLine("Access granted.");
            i = 4;
        }
        else
        {
            Console.WriteLine("Access denied.");
        }
    };
