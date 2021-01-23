    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace MethodsExceptions2
    {
      class Program
    {
        public static string firstName { get; set; }
        public static string lastName { get; set; }
        public static string birthDay { get; set; }
        static void Main(string[] args)
        {
            GetStudentInformation();
            PrintStudentDetails(firstName, lastName, birthDay);
            Console.ReadKey();
        }
        private static void PrintStudentDetails(string firstName, object lastName, object birthDay)
        {
            Console.WriteLine("{0} {1} was born on: {2}", firstName, lastName, birthDay);
        }
        private static void GetStudentInformation()
        {
            Console.WriteLine("Enter the student's first name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter the student's last name");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter the student's birthday");
            birthDay = Console.ReadLine();
        }
      
    }
    }
