      Console.Write("Enter the number of times to print \"Yay!\": ");
      string entry = Console.ReadLine();
      bool print = true; 
      try {      
        // int.Parse is within the try {} scope now
        var number = int.Parse (entry);
        
        while(print) {
          ...
        }
      }
      catch(FormatException) {
        Console.WriteLine("You must enter a whole number.");
      }
