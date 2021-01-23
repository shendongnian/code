    public class SystemConsumer
    {
        private ISystem _system;
        public SystemConsumer(ISystem system)
        {
            _system = system;
        }
    }
    public interface ISystem
    {
        void ExecuteOperation1();
    }
