    public class JobRunner
    {
        public static void Main(string[] args)
        {
            var container = JobRunnerIoC.BuildContainer();
    
            // Find out all types that are registered as an IJob
            var jobTypes = container.ComponentRegistry.Registrations
                .Where(registration => typeof(IJob).IsAssignableFrom(registration.Activator.LimitType))
                .Select(registration => registration.Activator.LimitType)
                .ToArray();
    
            // Run each job in its own lifetime scope
            var jobTasks = jobTypes
                .Select(async jobType => 
                {
                    using (var scope = container.BeginLifetimeScope(JobRunnerIoC.LifetimeScopeTag))
                    {
                        var job = scope.Resolve(jobType) as IJob;
                        await job.Run();
                    }
                });
    
            await Task.WhenAll(jobTasks);
        }
    }
