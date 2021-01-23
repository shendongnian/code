    public interface IDefaultProcessor
    {
        void Process(IProcess p);
        TResult Process<TResult>(IProcess p);
    }
