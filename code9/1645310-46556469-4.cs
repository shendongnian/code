    public interface IJob
    {
        int JobSequence { get; }
        Task RunJob();
    }
