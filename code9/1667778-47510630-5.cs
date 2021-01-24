    using System;
    
    namespace CSharpBasics
    {
        class Program
        {
            public static double? CelciusToFarenheit(string celciusTemperature)
            {
                //Converting string to a double for conversion
                double celcius;
                if (Double.TryParse(celciusTemperature, out celcius))
                {
                    double fahrenheit = (celcius * 9 / 5) + 32;
                    return fahrenheit;
                }
                else
                {
                    return null;
                }
            }
    
            public static void Main(string[] args)
            {
                var userInput = GetCelsiusInputFromUser();
                var output = CelciusToFarenheit(userInput);
                PrintOutput(output);
            }
    
            private static void PrintOutput(double? output)
            {
                if (output == null)
                {
                    Console.WriteLine("Invalid code");
                }
                else
                {
                    Console.WriteLine("The conversion from Celcius to Fahrenheit is: " + output);
                }
            }
    
            private static string GetCelsiusInputFromUser()
            {
                Console.WriteLine("Please enter a celsius value for conversion:");
                var userInput = Console.ReadLine();
                return userInput;
            }
        }
    }
