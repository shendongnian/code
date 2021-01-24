    public class RunProcess
    {
        public void Execute(IEnumerable<IJob> jobs)
        {
            jobs.OrderBy(job => job.JobSequence)
                .ToList()
                .ForEach(async job => await job.RunJob());
        }
    }
