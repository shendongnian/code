    class Program
    {
        static string firstName;
        static string lastName;
        static string birthday;
        static void Main(string[] args)
        {
            GetStudentInformation();
            PrintStudentDetails(firstName, lastName, birthday);
            Console.ReadKey();
        }
        static void GetStudentInformation()
        {
            Console.WriteLine("Enter the student's first name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter the student's last name");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter the student's birthday");
            birthday = Console.ReadLine();
        }
        static void PrintStudentDetails(string first, string last, string birthday)
        {
            Console.WriteLine("{0} {1} was born on: {2}", first, last, birthday);
        }
    }
