    using System;
    namespace My_Fist_Console_Game
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Airport Sim: Console Edition (literally)");
                Console.Write("Type your first name here: ");
                string firstName = Console.ReadLine();
                Console.Write("Type your last name here: ");
                string lastName = Console.ReadLine();
                string title;
                while (title != "Mr. " && title != "Ms. ")
                {
                    Console.Write("are you male or female? Input male, if you are male       or imput female if you are female");
                    string userValue = Console.ReadLine();
                    if ((userValue == "male") || (userValue == "Male"))
                    {
                        title = "Mr. ";
                    }
                    else if ((userValue == "female") || (userValue == "Female"))
                    {
                        title = "Ms. ";
                    }
                }
                string fullName = firstName + " " + lastName;
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Flight Attendant: ");
                Console.WriteLine("    Hello " + title + " " + lastName);
                Console.ReadLine();
            }
        }
    }
