    const string pass = "Password";            
    string attempt;
    int attempt = 0;
    do
    {
        Console.Write("Please enter password: ");
        attempt = Console.ReadLine();
        if (attempt == pass)
        {
            Console.WriteLine("Access granted.");
        }
        else
        {
            Console.WriteLine("Access denied.");
            attempt++;
        }
    } while (attempt <= 3 && attempt != pass);
