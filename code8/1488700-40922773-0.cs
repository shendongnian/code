    public class JobAdHocHandler : BaseHandler, IJobHandler
    {
        public MinimumResultModel Handle(MinimumCommandModel message)
        {
            var result = new MinimumResultModel {Id = "-1", PayloadAsString = message.FullPayloadString};
            try
            {
                var info = message.MinimumPayload.JobInfo;
                SetupInstance(info); // <<-- SOLUTION (in BaseHandler)
                var job = JobHandler.GetJob(info); // <<-- SOLUTION (in BaseHandler)
                result.Id = BackgroundJob.Enqueue(() => job.Execute(null, message.FullPayloadString, JobCancellationToken.Null));
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex, ex.Message);
                result.Exception = ex;
            }
            AppDomain.Unload(JobAppDomain);
            return result;
        }
        public bool AppliesTo(JobType jobType) => jobType == JobType.AdHoc;
    }
    public class BaseHandler : MarshalByRefObject
    {
        protected internal AppDomain JobAppDomain;
        protected internal BaseHandler JobHandler;
        protected internal void SetupInstance(JobInfoPayload info)
        {
            var ads = new AppDomainSetup
            {
                ApplicationBase = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName,
                DisallowBindingRedirects = false,
                DisallowCodeDownload = true,
                PrivateBinPath = info.JobClassName,
                ApplicationName = info.JobName,
            };
            JobAppDomain = AppDomain.CreateDomain(info.JobName, null, ads);
            JobHandler = (BaseHandler)JobAppDomain.CreateInstanceAndUnwrap(typeof(BaseHandler).Assembly.FullName, typeof(BaseHandler).FullName);
        }
        protected internal IJob GetJob(JobInfoPayload info)
        {
            var assembly = Assembly.LoadFrom(info.JobClassName + @"\" + info.JobClassName + ".dll");
            var assemblyType = assembly.GetType(info.AssemblyName);
            var job = Activator.CreateInstance(assemblyType) as IJob;
            if (job == null)
                throw new Exception("Unable to create job: " + info.JobClassName);
            return job;
        }
    }
