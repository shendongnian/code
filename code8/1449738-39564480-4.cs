    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {       
                string firstName, lastName, birthday;
                ClientsDetails(ref firstName, ref lastName, ref birthday);
                Print(firstName, lastName, birthday);
                Console.ReadKey();
            }
    
            public static void ClientsDetails(ref string firstName, ref string lastName, ref string birthday)
            {
                Console.Write("Client's first name: ");
                firstName = Console.ReadLine();
                Console.Write("Client's last name: ");
                lastName = Console.ReadLine();
                Console.Write("Client's birthdate: ");
                birthday = Console.ReadLine();
            }
    
            public static void Print(string first, string last, string birthday)
            {
                Console.WriteLine(String.Format("Client : {0} {1} was born on: {2}", first, last, birthday));
            }
        }
    }
