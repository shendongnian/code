    public interface ILogger
    {
        void Log(string message);
    }
    class BasicLogger : ILogger
    {
        public void Log(string message);
        Console.WriteLine(message); //Or use whatever output method is suitable
    }
    class StatefulLogger : ILogger, IDisposable
    {
        public StatefulLogger()
        {
            StartSession();
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
        }
        private void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            EndSession();
        }
        public void Dispose()
        {
            EndSession();
        }
        private void StartSession()
        {
            Console.WriteLine("Logger session started.");
            //Do Stuff
        }
        private void EndSession()
        {
            AppDomain.CurrentDomain.ProcessExit -= CurrentDomain_ProcessExit;
            //Do stuff
            Console.WriteLine("Logger session ended.");
        }
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
