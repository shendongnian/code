    public class QuartzStartup
        {
            private IScheduler _scheduler; // after Start, and until shutdown completes, references the scheduler object
            private readonly IServiceProvider container;
    
            public QuartzStartup(IServiceProvider container)
            {
                this.container = container;
            }
    
            // starts the scheduler, defines the jobs and the triggers
            public void Start()
            {
                if (_scheduler != null)
                {
                    throw new InvalidOperationException("Already started.");
                }
    
                var schedulerFactory = new StdSchedulerFactory();
                _scheduler = schedulerFactory.GetScheduler().Result;
                _scheduler.JobFactory = new JobFactory(container);
                _scheduler.Start().Wait();
    
                var voteJob = JobBuilder.Create<VoteJob>()
                    .Build();
    
                var voteJobTrigger = TriggerBuilder.Create()
                    .StartNow()
                    .WithSimpleSchedule(s => s
                        .WithIntervalInSeconds(60)
                        .RepeatForever())
                    .Build();
    
                _scheduler.ScheduleJob(voteJob, voteJobTrigger).Wait();
            }
    
            // initiates shutdown of the scheduler, and waits until jobs exit gracefully (within allotted timeout)
            public void Stop()
            {
                if (_scheduler == null)
                {
                    return;
                }
    
                // give running jobs 30 sec (for example) to stop gracefully
                if (_scheduler.Shutdown(waitForJobsToComplete: true).Wait(30000))
                {
                    _scheduler = null;
                }
                else
                {
                    // jobs didn't exit in timely fashion - log a warning...
                }
            }
        }  
