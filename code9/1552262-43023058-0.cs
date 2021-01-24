        static void Main(string[] args)
        {
            while (true)
            {
                int temperature;
                Console.WriteLine("Enter the temp");
                string choice = Console.ReadLine();
                if (choice.ToUpper().Equals("Q"))
                    break;
                temperature = Convert.ToInt32(choice);
                if (temperature < 17 || temperature > 25)
                {
                    Console.WriteLine("Temp is {0} and its too {1} to take a bath", temperature, temperature < 17 ? "cold" : "hot");
                }
                else
                {
                    Console.WriteLine("Temp is MADE TO 20, thou it is {0}, its ok to bath", temperature);
                }
            }
        }
