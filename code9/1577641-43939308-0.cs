    private static double ReadValue(string title) {
      double result = 0.0;
      Console.WriteLine(title);
      
      while (!double.Parse(Console.ReadLine(), out result))
        Console.WriteLine("Please enter numbers only");
      return result;  
    }
