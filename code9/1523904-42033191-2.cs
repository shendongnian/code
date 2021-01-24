    namespace password
        {
            class Program
            {
                static void Main(string[] args)
                {  
                    String Samsonpass = "12345";
                    String Riazpass = "hyperion";
                    String mypass = "CSGOPRO";
                    String Samson = "Samson";
                    String Riaz = "Riaz";
                    String Curstin = "Curstin";
        
                    Console.Write("Enter your name :");
                    string answer = Console.ReadLine();
                    Console.Write("Enter your password :");
                    string password = Console.ReadLine(); 
        
                    if (answer == Curstin && password == mypass)
                    {
                        Console.Write("Welcome Curstin");
                    }
                    else if (answer == Riaz && password == Riazpass)
                    {
                        Console.Write("Welcome Riaz");
                    }
                    else if (answer == Samson && password == Samsonpass)
                    {
                        Console.Write("Welcome Samson");
                    }
                    else
                    {
                        Console.Write("Invalid user or password !");
                    }
                    Console.Readline();
        
                }
            }
        }
