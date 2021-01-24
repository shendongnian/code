    using Quartz;
    using Quartz.Impl;
    using Quartz.Impl.Matchers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Quartz_test
    {
        public class SimpleJob : IJob
        {
            public void Execute(IJobExecutionContext context)
            {
                Console.WriteLine("hello there");
            }
        }
    
        class Program
        {
    
            private static void GetAllJobs(IScheduler scheduler)
            {
                IList<string> jobGroups = scheduler.GetJobGroupNames();
                // IList<string> triggerGroups = scheduler.GetTriggerGroupNames();
                Console.Write("START ===== \n is start? " + scheduler.IsStarted);
                Console.WriteLine("is stop? " + scheduler.IsShutdown);
                foreach (string group in jobGroups)
                {
                    var groupMatcher = GroupMatcher<JobKey>.GroupContains(group);
                    var jobKeys = scheduler.GetJobKeys(groupMatcher);
                    Console.WriteLine();
                    foreach (var jobKey in jobKeys)
                    {
                        var detail = scheduler.GetJobDetail(jobKey);
                        var triggers = scheduler.GetTriggersOfJob(jobKey);
                        foreach (ITrigger trigger in triggers)
                        {
                            Console.WriteLine("group : " + group);
                            Console.WriteLine("name : " + jobKey.Name);
                            Console.WriteLine("desc : " + detail.Description);
                            Console.WriteLine("trg name : " + trigger.Key.Name);
                            Console.WriteLine("trg group : " + trigger.Key.Group);
                            Console.WriteLine("trg type : " + trigger.GetType().Name);
                            Console.WriteLine("trg state : " + scheduler.GetTriggerState(trigger.Key));
                            DateTimeOffset? nextFireTime = trigger.GetNextFireTimeUtc();
                            if (nextFireTime.HasValue)
                            {
                                Console.WriteLine("next trigger? : " + nextFireTime.Value.LocalDateTime.ToString());
                            }
    
                            DateTimeOffset? previousFireTime = trigger.GetPreviousFireTimeUtc();
                            if (previousFireTime.HasValue)
                            {
                                Console.WriteLine("previous trigger? : " + previousFireTime.Value.LocalDateTime.ToString());
                            }
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("===== END \n");
            }
    
            static void ScheduleTask() 
            {
                IScheduler scheduler = null;
                IJobDetail job = null;
                ITrigger trigger = null;
    
                try
                {
                    // construct a scheduler factory
                    ISchedulerFactory schedFact = new StdSchedulerFactory();
                    // get a scheduler
                    scheduler = schedFact.GetScheduler();
                    scheduler.Start();
    
                    job = JobBuilder.Create<SimpleJob>()
                        .WithIdentity("myJob", "group1")
                        .Build();
                    trigger = TriggerBuilder.Create()
                        .WithSimpleSchedule(x => x.WithIntervalInSeconds(10).WithRepeatCount(3))
                        .Build();
    
                    scheduler.ScheduleJob(job, trigger);
    
                    GetAllJobs(scheduler);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.ToString());
                }
                finally
                {
                    GetAllJobs(scheduler);
    
                    TimeSpan spn = TimeSpan.FromSeconds(100L);
                    Thread.Sleep(spn);
    
                    
                    scheduler.Shutdown(true);
    
                }
    
            }
    
            static void Main(string[] args)
            {
                ScheduleTask();
                //link to scheduler is lost here
                //how to stop SimpleJob execution?
                //Console.ReadLine();
            }
        }
    }
