    using System.Globalization;
    ...
    private static double ReadDouble(string title) {
      while (true) {
        Console.WriteLine(title);
    
        string userInput = Console.ReadLine();
    
        double result;
    
        if (double.TryParse(userInput, 
                            NumberStyles.Any, 
                            CultureInfo.InvariantCulture, 
                            out result))
          return result;
    
        Console.WriteLine("Sorry, incorrect format. Enter it again, please.");  
      }
    }
    
