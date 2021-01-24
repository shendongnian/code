    static string MyPipeName = $"MyApp_{Environment.UserDomainName}_{Environment.UserName}";
    static void Main(string[] args)
    {
        bool created; // true if Mutex is created by this process 
        using(var mutex = new Mutex(false, @"Local\" + MyPipeName, out created)) // this needs proper securing
        {
            var gotit = mutex.WaitOne(2000); // take ownership
            if (!created)
            {
                if (gotit) 
                {
                    args = SecondInstance(mutex);
                    Console.WriteLine("I'm the second instance");
                }
                else 
                {
                    // no idea what to do here, log? crash? explode?
                }
            } 
            else 
            {
                FirstInstance(mutex);
                Console.WriteLine("I'm the first instance");
            }
            ProgramLoop(args); // our main program, this can be Application.Run for Winforms apps.
        }
    }
