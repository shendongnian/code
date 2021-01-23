    public interface ILogger
    {
        void LogB();
        bool LogA();
    }
    public class LoggerA : ILogger
    {
        public bool LogA()
        {
            return true;
        }
        public void LogB()
        {
            LogA();
        }
    }
    public class LoggerB : ILogger
    {
        public bool LogA()
        {
            LogB();
            return true;
        }
        public void LogB()
        {
            // Perform some work.
        }
    }
    public interface ISomeMethod
    {
        void SomeMethodBNeeds();
    }
    public class D : ISomeMethod
    {
        public void SomeMethodBNeeds()
        {
            // Perform some work.
        }
    }
    class C
    {
        ISomeMethod myLogger;
        public C()
        {
            myLogger = new D();
        }
        protected void ProgramLaunched()
        {
            myLogger.SomeMethodBNeeds();
        }
        protected void ProgramStopped()
        {
        }
        protected void ProgramResumed()
        {
            myLogger.SomeMethodBNeeds();
        }
        protected void ProgramPaused()
        {
        }
    }
