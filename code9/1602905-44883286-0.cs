    public interface IChainedWork
    {
        int DoWork();
        IChainedWork Next { get; }
    }
