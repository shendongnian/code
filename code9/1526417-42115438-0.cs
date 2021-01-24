    case "1":
          System.Console.Write("Please enter the Celsius temperature: ");
          var userInput = System.Console.ReadLine();            
          F = TemperatureConverter.CelsiusToFahrenheit(userInpug);                 
          System.Console.WriteLine("{userInput} Celsius is {0:F2} Fahrenheit", F);
          break;
