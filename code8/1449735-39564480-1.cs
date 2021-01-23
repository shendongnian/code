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
                string person = ClientsDetails();
                Print(person[0], person[1], person[2]);
                Console.ReadKey();
            }
    
            public static string[] ClientsDetails()
            {
                string[] returnValue = new string[3];
                Console.Write("Client's first name: ");
                returnValue[0] = Console.ReadLine();
                Console.Write("Client's last name: ");
                returnValue[1] = Console.ReadLine();
                Console.Write("Client's birthdate: ");
                returnValue[3] = Console.ReadLine();
                return returnValue;
            }
    
            public static void Print(string first, string last, string birthday)
            {
                Console.WriteLine(String.Format("Client : {0} {1} was born on: {2}", first, last, birthday));
            }
        }
    }
