    class LeapYear
    {
        static void Main(string[] args)
        {
            for (int input = 0; input < 10;) // Ask user until he enters year 10 times correctly
            {
                Console.Write("Please enter a year: ");
                try
                {
                    int year = int.Parse(Console.ReadLine());
                    if (DateTime.IsLeapYear(year))
                    {
                        Console.WriteLine($"{year} is leap");
                        input++;
                    }
                    else
                        Console.WriteLine($"{year} is not leap");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Argument Out Of Range");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad Format");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Overflow");
                }
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
