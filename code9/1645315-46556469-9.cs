    public class JobA : IJob
    {
        public int JobSequence => 1;
        public void RunJob()
        {
            Console.WriteLine("Ran job A");
        }
    }
    public class JobB : IJob
    {
        public int JobSequence => 2;
        public void RunJob()
        {
            Console.WriteLine("Ran job B");
        }
    }
    public class JobC : IJob
    {
        public int JobSequence => 3;
        public void RunJob()
        {
            Console.WriteLine("Ran job C");
        }
    }
