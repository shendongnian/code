    class Program
    {
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream("<PATH_TO_THE_SAME_FILE_AS_SERVICE>", <FileMode.Here>, <FileAccess.Here>);
            // create service controller that will control "MeService" service
            ServiceController Controller = new ServiceController("MeService");
            if (Controller.Status == ServiceControllerStatus.Stopped)
            {
                Controller.Start();
            }
            while (Controller.Status != ServiceControllerStatus.Running)
            ;
            Controller.ExecuteCommand(1); // redirect the stream.           
            string command = string.Empty;
            while( ( command = Console.ReadLine() ) != "exit" )
            {
                if(command == "refresh")
                {
                    if (Controller.Status == ServiceControllerStatus.Running)
                    {
                        Controller.ExecuteCommand(1337);
                        string performance = fileStream.ReadLine();
                        Console.WriteLine(performance);
                    } 
                }
            }
        }
    }
