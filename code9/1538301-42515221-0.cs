    public interface IContract
    {
        void DoSomething();
    }
    
    public interface IContractChanged:IContract
    {
        void DoSomethingMore();
    }
