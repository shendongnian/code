    public class Full: Access.Job
    {
        public string WrappedJobName { get { return this.JobName; } }
        public string WrappedJobName => this.JobName; //C# 6.0 syntax
    }
    Full mFull = new Full();
    Console.WriteLine(mFull.WrappedJobName);
