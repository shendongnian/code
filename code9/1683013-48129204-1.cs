    static void FirstInstance(Mutex mutex)
    {
        StartSecondInstanceHandler += (args) => 
        {
            using(var srv = new NamedPipeServerStream(MyPipeName)) // this needs proper securing
            {
                mutex.ReleaseMutex();
                // kick off a second instance of this app
                Relaunch();
                
                srv.WaitForConnection();
                using(var sr = new StreamReader(srv))
                {
                    using(var sw = new StreamWriter(srv))    
                    {
                        Trace.WriteLine("Server Started and writing");
                        // send the arguments to the second instance
                        sw.WriteLine(args);
                        sw.Flush();
                        Trace.WriteLine("Server done writing");
                        // the client send back an ack, is not strictly needed
                        Trace.WriteLine("ack: {0}", sr.ReadLine());
                    }
                }
                mutex.WaitOne();
            }
        };
    }
    // our public static delegate, accessible by calling
    // Program.StartSecondInstanceHandler("/fubar");
    public static Action<string> StartSecondInstanceHandler = null;
    
    // just launch the app
    static void Relaunch()
    {
        var p = new ProcessStartInfo();
        p.FileName = Environment.CommandLine;
        p.UseShellExecute = true;
        p.Verb = "runas";
        var started = Process.Start(p);
    } 
