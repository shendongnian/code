       public interface IHandler<T> where T : new()
        {
            T Process(IProcess process);
        }
    
        public interface IProcess
        {
        }
    
        public class BoolHandler : IHandler<bool>
        {
            public bool Process(IProcess process)
            {
                throw new NotImplementedException();
            }
        }
