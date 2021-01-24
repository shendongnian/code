        class Program
        {
            static void Main(string[] args)
            {
               string command = Console.ReadLine();
    
                   switch (command.ToUpper())
                    {
                    case "CMD":
                        Console.WriteLine("CMD");
                        break;
                    case "CALCULATOR":
                         cal.ShowDialog();
                        break;
                    default:
                       Console.WriteLine("Default");
                       break;
                   }
    
            }
        }
    
