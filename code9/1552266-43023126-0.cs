    static void Main(string[] args)
          {
                while (true)
                {
                    int temperature;
                    Console.WriteLine("Enter the temp");
                    string choice = Console.ReadLine();
    
                    if ( int.TryParse(choice, out temperature))
                    {
    
                        if (temperature < 17 || temperature > 25)
                        {
                            Console.WriteLine("Temp is {0} and its too cold to take a bath", temperature);
                        }
                        else
                        {
                            Console.WriteLine("Temp is MADE TO 20, thou it is {0}, its ok to bath", temperature);
                        }
    
                    }
                    else if(choice != "Q" || choice != "q")
                    {
                        Console.WriteLine("\n * Invalid Entry * ");
                    }
    
                   
    
                    if (choice == "Q" || choice== "q")
                        break;
    
                    
                }
            }
