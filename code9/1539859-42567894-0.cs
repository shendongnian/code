     static void Main(string[] args)
        {
            double a, b,Result;
            while (true)
            {
                Console.WriteLine("\t\t\t\t\t\t\tCalcualtor");
                Console.WriteLine("\t\t\t\t\t\t\t----------");
                Console.WriteLine("put Number Plz");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("put other Number Plz");
                b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Choose :*,+,-,/");
                bool successful;
                do
                {
                    string uservalue = Console.ReadLine();
                    if (uservalue == "*")
                    {
                        Result = a * b;
                        Console.Write("Resultat= " + a * b);
                        successful = true;
                    }
                    else if (uservalue == "+")
                    {
                        Result = a + b;
                        Console.Write("Resultat= " + (a + b));
                        successful = true;
                    }
                    else if (uservalue == "-")
                    {
                        Result = a - b;
                        Console.Write("Resultat= " + (a - b));
                        successful = true;
                    }
                    else if (uservalue == "/")
                    {
                        Result = a / b;
                        Console.Write("Resultat= " + (a / b));
                        successful = true;
                    }
                    else 
                    {
                      Console.WriteLine("put right operator !!!");
                        successful = false ;
                    }
                   } 
                while (!successful);
                {
                Console.ReadLine();
                Console.Clear();
                }
               }
           }    
        }
    }
