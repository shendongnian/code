    public class JobA : IJob
    {
        public JobA()
        {
            JobSequence = 1;
        }
        public int JobSequence { get;}
        public Task RunJob()
        {
            Console.WriteLine("Ran job A");
            return Task.FromResult(0);
        }
    }
    public class JobB : IJob
    {
        public JobB()
        {
            JobSequence = 2;
        }
        public int JobSequence { get; }
        public Task RunJob()
        {
            Console.WriteLine("Ran job B");
            return Task.FromResult(0);
        }
    }
    public class JobC : IJob
    {
        public JobC()
        {
            JobSequence = 3;
        }
        public int JobSequence { get; }
        public Task RunJob()
        {
            Console.WriteLine("Ran job C");
            return Task.FromResult(0);
        }
    }
