    public class A : IA
    {
        private readonly ILog logger;
    
        public B(ILog logger)
        {
            this.logger = logger;
        }
    
        private bool Step()
        {
            // some logic
            logger.Error("Something specific here.")
            // more logic
            return true;
        }
    
        public void Run()
        {
            for (int i = 0; i < 5; ++i)
            {
                logger.Info("A");
                Step();
            }
        }
    }
    
    public class B : IA
    {
        private readonly ILog logger;
    
        public B(ILog logger)
        {
            this.logger = logger;
        }
    
        private bool Step()
        {
            return true;
        }
    
        public void Run()
        {
            for (int i = 0; i < 4; ++i)
            {
                logger.Info("B");
                Step();
            }
        }
    }
    
    public interface IA
    {
        void Run();
    }
    
    public interface ILog
    {
        void Info(string message);
    }
    
    public class ConsoleLogger
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }
    }
    
    public class NoopLogger
    {
        public void Info(string message)
        {
    
        }
    }
