    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        struct Person{
            public static FirstName;
            public static LastName;
            public static Birthday;
        }
        class Program
        {
            static void Main(string[] args)
            {                
                Person person = ClientsDetails();
                Print(person.FirstName, person.LastName, person.Birthday);
                Console.ReadKey();
            }
    
            public static Person ClientsDetails()
            {
                Person returnValue = new Person();
                Console.Write("Client's first name: ");
                returnValue.FirstName = Console.ReadLine();
                Console.Write("Client's last name: ");
                returnValue.LastName = Console.ReadLine();
                Console.Write("Client's birthdate: ");
                returnValue.Birthday = Console.ReadLine();
                return returnValue;
            }
    
            public static void Print(string first, string last, string birthday)
            {
                Console.WriteLine(String.Format("Client : {0} {1} was born on: {2}", first, last, birthday));
            }
        }
    }
