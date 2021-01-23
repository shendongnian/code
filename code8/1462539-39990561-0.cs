    class Program
    {
        static void Main(string[] args)
        {
            var userInputs = GetStudentInformation();
            PrintStudentDetails(userInputs);
            Console.ReadKey();
        }
        static Tuple<string, string, string> GetStudentInformation()
        {
            Console.WriteLine("Enter the student's first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the student's last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the student's birthday");
            string birthDay = Console.ReadLine();
            return new Tuple<string, string, string>(firstName, lastName, birthDay);
        }
        static void PrintStudentDetails(Tuple<string, string, string> userInputs)
        {
            Console.WriteLine("{0} {1} was born on: {2}", userInputs.Item1, userInputs.Item2, userInputs.Item3);
        }
    }
