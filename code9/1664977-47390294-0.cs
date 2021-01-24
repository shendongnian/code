    private static int GetUserInput()
    {
      while (true)
      {
        int outputValue;
        Console.WriteLine("Skriv in temperaturen i Fahrenheit: ");
        var inputValue = Console.ReadLine();
        var userInputIsInteger = int.TryParse(inputValue, out outputValue);
        if (!userInputIsInteger)
           {
             Console.WritLine("Only integer values can be accepted as input");
           }
        if (userInputIsInteger || inputValue == "q") // in user type Q he wants to exit an app
        {
          return outputValue;
        }
      }
    }
