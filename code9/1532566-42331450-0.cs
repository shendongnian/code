    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type in a command.");
            string command = Console.ReadLine();
            YourMethod(command);
            Console.ReadKey(); //prevents the console closing before you can read the output
        }
        static void YourMethod(string cmd)
        {
            if(cmd == "asd")
            {
                Console.WriteLine("ASD");
            }
            else if(cmd == "asd2")
            {
                Console.WriteLine("You wrote ASD2");
            }
            else
            {
                Console.WriteLine("Not found.");
            }
        }
    }
