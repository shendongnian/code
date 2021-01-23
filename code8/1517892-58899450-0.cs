    using eForms.Core;
    using Hangfire;
    using Hangfire.SqlServer;
    using System;
    using System.ComponentModel;
    using System.Web.Hosting;
    
    namespace eForms.AdminPanel.Jobs
    {
        public class JobManager : IJobManager, IRegisteredObject
        {
            public static readonly JobManager Instance = new JobManager();
            //private static readonly TimeSpan ZeroTimespan = new TimeSpan(0, 0, 10);
            private static readonly object _lockObject = new Object();
            private bool _started;
            private BackgroundJobServer _backgroundJobServer;
            private JobManager()
            {
            }
            public int Schedule(JobInfo whatToDo)
            {
                int result = 0;
                if (!whatToDo.IsRecurring)
                {
                    if (whatToDo.Delay == TimeSpan.Zero)
                        int.TryParse(BackgroundJob.Enqueue(() => Run(whatToDo.JobId, whatToDo.JobType.AssemblyQualifiedName)), out result);
                    else
                        int.TryParse(BackgroundJob.Schedule(() => Run(whatToDo.JobId, whatToDo.JobType.AssemblyQualifiedName), whatToDo.Delay), out result);
                }
                else
                {
                    RecurringJob.AddOrUpdate(whatToDo.JobType.Name, () => RunRecurring(whatToDo.JobType.AssemblyQualifiedName), Cron.MinuteInterval(whatToDo.Delay.TotalMinutes.AsInt()));
                }
    
                return result;
            }
    
            [DisplayName("Id: {0}, Type: {1}")]
            [HangFireYearlyExpirationTime]
            public static void Run(int jobId, string jobType)
            {
                try
                {
                    Type runnerType;
                    if (!jobType.ToType(out runnerType)) throw new Exception("Provided job has undefined type");
                    var runner = runnerType.CreateInstance<JobRunner>();
                    runner.Run(jobId);
                }
                catch (Exception ex)
                {
                    throw new JobException($"Error while executing Job Id: {jobId}, Type: {jobType}", ex);
                }
            }
    
            [DisplayName("{0}")]
            [HangFireMinutelyExpirationTime]
            public static void RunRecurring(string jobType)
            {
                try
                {
                    Type runnerType;
                    if (!jobType.ToType(out runnerType)) throw new Exception("Provided job has undefined type");
                    var runner = runnerType.CreateInstance<JobRunner>();
                    runner.Run(0);
                }
                catch (Exception ex)
                {
                    throw new JobException($"Error while executing Recurring Type: {jobType}", ex);
                }
            }
    
            public void Start()
            {
                lock (_lockObject)
                {
                    if (_started) return;
                    if (!AppConfigSettings.EnableHangFire) return;
                    _started = true;
                    HostingEnvironment.RegisterObject(this);
                    GlobalConfiguration.Configuration
                        .UseSqlServerStorage("SqlDbConnection", new SqlServerStorageOptions { PrepareSchemaIfNecessary = false })
                       //.UseFilter(new HangFireLogFailureAttribute())
                       .UseLog4NetLogProvider();
                    //Add infinity Expiration job filter
                    //GlobalJobFilters.Filters.Add(new HangFireProlongExpirationTimeAttribute());
    
                    //Hangfire comes with a retry policy that is automatically set to 10 retry and backs off over several mins
                    //We in the following remove this attribute and add our own custom one which adds significant backoff time
                    //custom logic to determine how much to back off and what to to in the case of fails
    
                    // The trick here is we can't just remove the filter as you'd expect using remove
                    // we first have to find it then save the Instance then remove it 
                    try
                    {
                        object automaticRetryAttribute = null;
                        //Search hangfire automatic retry
                        foreach (var filter in GlobalJobFilters.Filters)
                        {
                            if (filter.Instance is Hangfire.AutomaticRetryAttribute)
                            {
                                // found it
                                automaticRetryAttribute = filter.Instance;
                                System.Diagnostics.Trace.TraceError("Found hangfire automatic retry");
                            }
                        }
                        //Remove default hangefire automaticRetryAttribute
                        if (automaticRetryAttribute != null)
                            GlobalJobFilters.Filters.Remove(automaticRetryAttribute);
                        //Add custom retry job filter
                        GlobalJobFilters.Filters.Add(new HangFireCustomAutoRetryJobFilterAttribute());
                    }
                    catch (Exception) { }
                    _backgroundJobServer = new BackgroundJobServer(new BackgroundJobServerOptions
                    {
                        HeartbeatInterval = new System.TimeSpan(0, 1, 0),
                        ServerCheckInterval = new System.TimeSpan(0, 1, 0),
                        SchedulePollingInterval = new System.TimeSpan(0, 1, 0)
                    });
                }
            }
            public void Stop()
            {
                lock (_lockObject)
                {
                    if (_backgroundJobServer != null)
                    {
                        _backgroundJobServer.Dispose();
                    }
                    HostingEnvironment.UnregisterObject(this);
                }
            }
            void IRegisteredObject.Stop(bool immediate)
            {
                Stop();
            }
        }
    }
