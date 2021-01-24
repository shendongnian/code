    public class JobA : IJob
    {
        public int JobSequence => 1;
        public Task RunJob()
        {
            Console.WriteLine("Ran job A");
            return Task.FromResult(0);
        }
    }
    public class JobB : IJob
    {
        public int JobSequence => 2;
        public Task RunJob()
        {
            Console.WriteLine("Ran job B");
            return Task.FromResult(0);
        }
    }
    public class JobC : IJob
    {
        public int JobSequence => 3;
        public Task RunJob()
        {
            Console.WriteLine("Ran job C");
            return Task.FromResult(0);
        }
    }
