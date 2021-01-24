    class Program
    {
        static Queue<string> commandQueue = new Queue<string>(new[] {"FirstCommand", "SecondCommand", "ThirdCommand"});
        static void Main(string[] args)
        {
            using (Queue<string>.Enumerator enumerator = commandQueue.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine("Type in next command or type exit to close application");
                    //this while is used to let user make as many mistakes as he/she wants.
                    while (true)
                    {
                        string command = Console.ReadLine();
                        if (command == "exit")
                        {
                            Environment.Exit(0);
                        }
                        //if typed command equals current command in queue ExecuteCommand and move queue to next one
                        if (command == enumerator.Current)
                        {
                            ExecuteCommand(command);
                            break;
                        }
                        else//Show error message
                        {
                            if (commandQueue.Contains(command))
                            {
                                Console.WriteLine("Wrong command.");
                            }
                            else
                            {
                                Console.WriteLine("Command not found.");
                            }
                        }
                    } 
                }
                Console.WriteLine("We are done here, press enter to exit.");
                Console.ReadLine();
            }
        }
        //Method that executes command according to its name
        static void ExecuteCommand(string commandName)
        {
            switch (commandName)
            {
                case "FirstCommand":
                    Console.WriteLine("FirstCommand executed");
                    break; 
                case "SecondCommand":
                    Console.WriteLine("SecondCommand executed");
                    break;
                case "ThirdCommand":
                    Console.WriteLine("ThirdCommand executed");
                    break;
                default:
                    Console.WriteLine("Command not found");
                    break;
            }     
        }
    }
