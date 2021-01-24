        public static double CelciusToFarenheit(double celcius)
        {
            double fahrenheit = (celcius * 9 / 5) + 32;
            return fahrenheit;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter a value for conversion:");
            var input = Console.ReadLine();
            
            double celcius;
            if (Double.TryParse(input, out celcius))
            {
                var result = CelciusToFarenheit(celcius);
                Console.WriteLine("The conversion from Celcius to Fahrenheit is: " + result);
            }
            else 
            {
                Console.WriteLine("Invalid code");
            }            
        }
