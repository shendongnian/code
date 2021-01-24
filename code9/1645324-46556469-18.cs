    public class RunMethods
    {
        public void Execute(IEnumerable<IMethod> jobs)
        {
            jobs.OrderBy(job => job.MethodSequence)
                .ToList()
                .ForEach(job => job.RunMethod());
        }
    }
