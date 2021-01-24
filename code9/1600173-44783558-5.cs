    public class JobA : JobBase<JobAData> {
        public JobA(JobAData data) : base(data) { }
        public void Run() {
            //can use JobData nicely here
        }
    }
