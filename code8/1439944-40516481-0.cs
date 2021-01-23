    public abstract class JobHandler<T> : JobHandler 
        where T: IJob
    {
        public override void Enqueue(string payload)
        {
            BackgroundJob.Enqueue<T>(x => x.Execute(payload));
        }
    }
