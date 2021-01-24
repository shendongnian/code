    Console.WriteLine("Enter a number: ");
    string input = Console.ReadLine();
    try
    {
        var number = int.Parse(input);
        if (number % 2 == 0)
            Console.WriteLine($"Entered number {number} is even.");
    
        else
            Console.WriteLine($"Entered number {number} is odd.");
    }
    catch (FormatException exc)
    {
        if(string.IsNullOrEmpty(input))
        {
            Console.WriteLine("You need to enter some value.");
        }
        else
        {
            Console.WriteLine("You need to enter a number.");
        }
                    
    }
    
    catch (Exception exc)
    {
        Console.WriteLine("You need to enter a number.");
    }
