    class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Please Enter The Year:");
                int year = int.Parse(Console.ReadLine());
                if (year%400 == 0 || (year%4 == 0 && year%100 != 0))
                {
                    Console.WriteLine("Leap Year");
                }
                else
                {
                    Console.WriteLine("Not Leap Year");
                }
                Console.ReadLine();
            }
        }
