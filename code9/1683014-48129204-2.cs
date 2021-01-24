    static string[] SecondInstance(Mutex mutex) 
    {
        string arguments = String.Empty;
        Console.WriteLine("Client NamedPipe starting");
        using(var nps = new NamedPipeClientStream(MyPipeName))
        {
            nps.Connect();  // we expect the server to be running
            
            using(var sr = new StreamReader(nps))
            {
                arguments = sr.ReadLine();
                Console.WriteLine($"received args: {arguments}");
                using(var sw = new StreamWriter(nps))
                {
                    sw.WriteLine("Arguments received!");
                }
            }
            mutex.ReleaseMutex(); // we're done
        }
        return arguments.Split(' '); // quick hack, this breaks when you send /b:"with spaces" /c:foobar
    }
