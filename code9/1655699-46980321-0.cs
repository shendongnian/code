    public interface IA
    {
        bool Step();
    }
    public class A : IA
    {
        public bool Step()
        {
            return true;
        }
    }
    public class B : IA
    {
        public bool Step()
        {
            return true;
        }
    }
    public class Logger : IA
    {
        private readonly IA _decorated;
        public Logger(IA decorated)
        {
            _decorated = decorated;
        }
        public bool Step()
        {
            Console.WriteLine("Before Step...");
            _decorated.Step();
            Console.WriteLine("Step completed.");
        }
    }
