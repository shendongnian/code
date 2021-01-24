    class Program
    {
        static private Queue<string> commandQueue = new Queue<string>(new[] {"FirstCommand", "SecondCommand", "ThirdCommand"});
        static void Main(string[] args)
        {
            using (Queue<string>.Enumerator enumerator = commandQueue.GetEnumerator())
            {
                enumerator.MoveNext();
                while (true)
                {
                    string command = Console.ReadLine();
                    //if typed command equals current command in queue ExecuteCommand and move queue to next one
                    if (command == enumerator.Current)
                    {
                        ExecuteCommand(command);
                        //if MoveNext returns false it means we are done with queue.
                        if (!enumerator.MoveNext())
                        {
                            Console.WriteLine("We are done here, press enter to exit.");
                            Console.ReadLine();
                            break;
                        }
                    }
                    else
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
