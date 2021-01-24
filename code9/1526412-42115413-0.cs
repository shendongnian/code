    case "1":
                    System.Console.Write("Please enter the Celsius temperature: ");
                    String userInput = System.Console.ReadLine();
                    System.Console.Write(userInput);
                    F = TemperatureConverter.CelsiusToFahrenheit(userInput);                 
                    System.Console.WriteLine(" Celsius is {0:F2} Fahrenheit", F);
                    break;
