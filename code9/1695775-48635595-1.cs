        class Program
        {
            static void Main(string[] args)
            {
               
             while((string command = Console.ReadLine()) != null)
             {
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
        }
    
