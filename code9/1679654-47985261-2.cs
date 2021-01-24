    var previousNumbers = new List<int>(); // Create list of previous numbers entered
    int number;
    
    Console.WriteLine($"Enter new number from 1 to 9 or 0 to exit.");
    
    var valueEntered = Console.ReadKey().KeyChar;
    
    // try converting key press to an int and check its not 0
    while (int.TryParse(valueEntered.ToString(), out number) && number != 0)
    {
       if (previousNumbers.Contains(number))
       {
          Console.WriteLine(" has already been entered, try again.");
       }
       else
       {
          // add you number to the list 
          previousNumbers.Add(number); 
          Console.WriteLine(" is a valid number and hasn't been used.");
       }
       // get next value and do the hokey pokey 
       valueEntered = Console.ReadKey().KeyChar; 
    }
