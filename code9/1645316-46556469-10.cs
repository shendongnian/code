    public class RunProcess
    {
        public void Execute(IEnumerable<IJob> jobs)
        {
            jobs.OrderBy(job => job.JobSequence)
                .ToList()
                .ForEach(job => job.RunJob());
        }
    }
