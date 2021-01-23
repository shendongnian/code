    using System;
    namespace Test {
        internal class Program {
            private static void Main(string[] args) {
                Console.WriteLine("This program adds two numbers.");
                var n1 = ReadInt("Enter n1: ");
                var n2 = ReadInt("Enter n2: ");
                var total = n1 + n2;
                Console.WriteLine("The total is {0}.", total);
                Console.Read(); //Just to keep the console window from closing. Press a key to exit.
            }
            private static int ReadInt(string message) {
                Console.Write(message);
                var sInt = Console.ReadLine();
                int ret;
                if (int.TryParse(sInt, out ret)) {
                    return ret;
                }
                throw new Exception("You must enter a valid number!");
            }
        }
    }
