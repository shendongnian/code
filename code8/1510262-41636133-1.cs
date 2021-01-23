    class Program
    {
        private static IScheduler _scheduler;
        static void Main(string[] args)
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            ISchedulerListener schedListener = new SchedulerListener();
            _scheduler = schedFact.GetScheduler();
            _scheduler.ListenerManager.AddSchedulerListener(schedListener);
            _scheduler.Start();
            UpdateJobs();
            string option = "";
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1 - Update Jobs");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        UpdateJobs();
                        break;
                }
            }
            while (true);
            Console.ReadLine();
        }
        private static void UpdateJobs()
        {
            //Delete old jobs
            foreach (String groupName in _scheduler.GetJobGroupNames())
            {
                foreach (JobKey newJobKey in _scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupContains(groupName)))
                {
                    _scheduler.DeleteJob(newJobKey);
                }
            }
            //Create new jobs
            List<Tuple<string, string>> pathsNamesDll = GetDllPathsAndNames();
            int jobNr = 1;
            foreach (Tuple<string,string> dllPathName in pathsNamesDll)
            {
                try
                {
                    IJobDetail job = null;
                    ITrigger trigger = null;
                    job = JobBuilder.Create<MapperJob>()
                                .WithIdentity("Job_" + jobNr, "Group_" + jobNr)
                                .UsingJobData("DLL_NAME", dllPathName.Item2)
                                .UsingJobData("DLL_PATH", dllPathName.Item1)
                                .Build();
                    trigger = TriggerBuilder.Create()
                           .WithIdentity("Job_" + jobNr, "Group_" + jobNr)
                           .StartAt(DateTime.Now) //To make the example easy I define all the start time to "Now"...
                           .WithSimpleSchedule(x => x
                               .WithIntervalInHours(24)//... and execute the Job every day.
                               .RepeatForever())
                           .Build();
                    _scheduler.ScheduleJob(job, trigger);
                    jobNr++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static List<Tuple<string, string>> GetDllPathsAndNames()
        {
            List<Tuple<string, string>> pathsNamesDll = new List<Tuple<string, string>>();
            //Here I fill the list getting the Dll Paths and the Class Names that implement the IJobExecution from an XML or some other way
            return pathsNamesDll;
        }
    }    
    public class MapperJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string dllPath = dataMap.GetString("DLL_PATH");
            string dllName = dataMap.GetString("DLL_NAME");
            AppDomain domain = AppDomain.CreateDomain(key.Name + "_" + key.Group + "_Execution_Domain");
            try
            {
                IJobExecution myObject = (IJobExecution)domain.CreateInstanceFromAndUnwrap(dllPath, dllName);
                myObject.SqlExecute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                AppDomain.Unload(domain);
            }
        }
    }
