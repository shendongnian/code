    if (selection == 3) {
      if (age >= 12)
        Console.WriteLine("You may enter")
      else {
        Console.WriteLine("Are you accompanied by an adult? Answer yes or no" );
    
        // Trim() - let's be nice and allow user to leave leading/trailing spaces
        string input = Console.ReadLine().Trim();
    
        // accompanied if user's input "y" or "yes"  
        bool accompanied = "yes".Equals(input, StringComparison.OrdinalIgnoreCase) ||
                           "y".Equals(input, StringComparison.OrdinalIgnoreCase); 
    
        if (accompanied)
          Console.WriteLine("You may pass.");
        else  
          Console.WriteLine("You are not allowed.");
      }
    }
