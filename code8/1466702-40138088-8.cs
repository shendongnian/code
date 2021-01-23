    public class Adaptor<T> : IHandler
    {
        private readonly IHandler<T> handler;
        public Adaptor(IHandler<T> handler)
        {
            this.handler = handler;
        }
        public T1 Process<T1>(int process)
        {
            if(!CanProcess<T1>())
                throw new Exception(
                    "Contract violated. I cannot handle type " + typeof(T1).Name);
            return (T1)(object)handler.Process(process);
        }
        public bool CanProcess<T1>()
        {
            return typeof (T1) == typeof (T);
        }
    }    
