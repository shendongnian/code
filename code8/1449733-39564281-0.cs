    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static String FirstName;
            private static String LastName;
            private static String Birthday;
            static void Main(string[] args)
            {
                ClientsDetails();
                Print(FirstName, LastName, Birthday);
                Console.ReadKey();
            }
    
            public static void ClientsDetails()
            {
                Console.Write("Client's first name: ");
                FirstName = Console.ReadLine();
                Console.Write("Client's last name: ");
                LastName = Console.ReadLine();
                Console.Write("Client's birthdate: ");
                Birthday = Console.ReadLine();
            }
    
            public static void Print(string first, string last, string birthday)
            {
                Console.WriteLine(String.Format("Client : {0} {1} was born on: {2}", first, last, Birthday));
            }
        }
    }
