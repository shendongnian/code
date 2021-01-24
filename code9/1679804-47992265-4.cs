    public static double GetTemperatureFromUser()
    {
         while (true)
         {
              Console.Write("Enter temperature in Fahrenheit: ");
              
              try
              {
                  var t = FahrToCels(Convert.ToDouble(Console.ReadLine()));
              
                  if (t < 73)
                  {
                      Console.Write("Temperature is too low. Try again.");
                  }
                  else if (t > 77)
                  {
                      Console.Write("Temperature is too high. Try again.");
                  }
                  else
                  {
                      return t;
                  }
             }
             catch (FormatException)
             {
                  Console.Write("Invalid number format. Try again.");
             }
             catch (OverflowException)
             {
                  Console.Write("Number is too large or too small. Try again.");
             }
         }
    } 
