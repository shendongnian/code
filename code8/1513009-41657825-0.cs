        static void Main(string[] args)
        {
            int tempurature;
            string celciusOrFahrenheit;
            Console.Write("Hello welcome to the temperature converter. Please provide the numerical value of your temperature. Enter your response here:");
            tempurature = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter F or C to define your temperature. Enter F or C here: ");
            celciusOrFahrenheit = Console.ReadLine();
            if (celciusOrFahrenheit.ToUpper() == "C")
            {
                Console.WriteLine("Temp converted to farenhite: " + ConvertToFahrenheit(tempurature));
            }
            if (celciusOrFahrenheit.ToUpper() == "F")
            {
                Console.WriteLine("Temp converted to celcius: " + ConvertToCelcius(tempurature));
            }
            Console.ReadKey();
        }
        public static int ConvertToFahrenheit(int temp)
        {
            int cToF = ((temp + 32 / 5) * 9);
            return cToF;
        }
        public static int ConvertToCelcius(int temp)
        {
            int fToC = ((temp - 32) / 9) * 5;
            return fToC;
        }
    }
