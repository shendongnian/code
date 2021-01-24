    Console.WriteLine("About to call Console.ReadLine in a loop.");
                Console.WriteLine("----");
                String s;
                do
                {
              
                    s = Console.ReadLine();
                    Regex regex = new Regex(@"[\d]");
    
                    if (regex.IsMatch(s))
                    {
                        Console.WriteLine("You entered an integer = " + s.ToString());
                    }
                    else
                    {
                        Console.WriteLine("You entered a String = " + s.ToString());
                    }
    
                } while (s != null);
                Console.WriteLine("---");
