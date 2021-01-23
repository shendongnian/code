    public interface ILogFactory
    {
        ILog Create();
    }
    public class DefaultLogFactory : ILogFactory
    {
        public ILog Create()
        {
            return new Log();
        }
    }
