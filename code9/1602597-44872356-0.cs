    var str = Console.ReadLine();
    if (string.IsNullOrEmpty(str))
    {
        Console.WriteLine("You need to enter some value.");
    }
    else
    {
        int number;
        if (!int.TryParse(str, out number))
        {
            Console.WriteLine("You need to enter a number.");
        }
        else
        {
            if (number % 2 == 0)
                Console.WriteLine($"Entered number {number} is even.");
            else
                Console.WriteLine($"Entered number {number} is odd.");
        }
    }
