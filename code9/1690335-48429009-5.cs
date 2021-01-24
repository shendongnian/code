    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            while (true)
            {
                if (context.CancellationToken.IsCancellationRequested)
                {
                    context.CancellationToken.ThrowIfCancellationRequested(); 
                    // After interrupt the job, the cancellation request activated
                }
            }
        }
    }
