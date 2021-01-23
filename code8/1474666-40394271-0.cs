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
            string RealUsername = "root";
            string RealPassword = "passwd";
            Console.Write("Username: ");
            string Username = Console.ReadLine();
            Console.Write("Password: ");
            string Password = Console.ReadLine();
            if (Username == RealUsername)
            {
                if (Password == RealPassword)
                {
                  Console.WriteLine("Correct Login");
                }
                else
                {
                  Console.WriteLine("Incorrect Login");
                }
            }
            else
            {
                Console.WriteLine("Incorrect Login");
            }
        }
    }
}
