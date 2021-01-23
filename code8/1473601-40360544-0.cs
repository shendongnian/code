    const string pass = "Password";            
    string attempt;
    
    int n = 0;
    do
    {
        Console.Write("Please enter password: ");
        attempt = Console.ReadLine();
        if (attempt == pass)
        {
            Console.WriteLine("Access granted.");
            break;
        }
        else
        {
            Console.WriteLine("Access denied.");
            n++;
        }
    } while (n<=3);
