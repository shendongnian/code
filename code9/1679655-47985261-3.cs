    var previousNumbers = new HashSet<int>(); // Create list of previous numbers entered
    int number;
    
    Console.WriteLine($"Enter new number from 1 to 9 or 0 to exit.");
    
    // try converting it to in, and check its not 0
    while (int.TryParse(Console.ReadLine(), out number) && number >= 1 && number <= 9)
    {
       if (!previousNumbers.Add(number))
       {
          Console.WriteLine($"{number} has already been entered, try again.");
       }
       else
       {
          Console.WriteLine($"{number} is a valid number and hasn't been used.");
       }
    }
