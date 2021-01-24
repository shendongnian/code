    public interface IData
    {
        string Data { get; set; }
    }
    public interface IJob<out T> where T : IData
    {
        T JobData { get; }
        void Run();
    }
    public class JobAData : IData
    {
        public string Data { get; set; }
    }
    public abstract class Abs_JobA : IJob<JobAData>
    {
        public abstract JobAData JobData { get; protected set; }
        public abstract void Run();
    }
    public class JobA : Abs_JobA
    {
        public override JobAData JobData
        {
            get;
            protected set;
        }
        public JobA(JobAData data)
        {
            this.JobData = data;
        }
        public override void Run()
        {
            //can use JobData nicely here
        }
    }
