     case "1":
         System.Console.Write("Please enter the Celsius temperature: ");
         F = System.Console.ReadLine();                 
         System.Console.WriteLine("{0} Celsius is {1:F2} Fahrenheit", F, TemperatureConverter.CelsiusToFahrenheit(F));
         break;
