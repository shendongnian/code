        static void Main(string[] args)
        {
            int age;
            int YearsToWork;
            Console.Write("Enter your name:");
            string name = Console.ReadLine();
            Console.Write("Enter your age:");
            age = Convert.ToInt32(Console.ReadLine());
            YearsToWork = 65 - age;
            Console.WriteLine("You will work: {0} years before you retire", YearsToWork);
            Console.Read();
        }
