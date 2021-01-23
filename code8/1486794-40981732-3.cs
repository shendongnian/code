    [assembly: OwinStartup(typeof(DiTestingApp.QuartzStartup))]
    namespace DiTestingApp
    {
        /// <summary>
        /// 
        /// </summary>
        public class QuartzStartup
        {
            private static readonly ILog Log = LogManager.GetLogger(typeof(QuartzStartup));
            /// <summary>
            /// Get the hangfire container.
            /// </summary>
            private static readonly Lazy<IUnityContainer> QuartzContainer = new Lazy<IUnityContainer>(() =>
            {
                var container = new UnityContainer();
                container.AddNewExtension<QuartzUnityExtension>();
                container.Configure(() => new HierarchicalLifetimeManager());
                return container;
            });
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="app"></param>
            public void Configuration(IAppBuilder app)
            {
                Log.Info("Quartz Startup Intitializing...");
                var container = QuartzContainer.Value;
                InitScheduler(container);
                Log.Info("Quartz Startup Intialization Complete...");
    
                var properties = new AppProperties(app.Properties);
                var cancellationToken = properties.OnAppDisposing;
                if (cancellationToken != CancellationToken.None)
                {
                    cancellationToken.Register(() =>
                    {
                        QuartzContainer.Value.Dispose();
                        Log.Info("Quartz container disposed (app pool shutdown).");
                    });
                }
            }
    
            private void InitScheduler(IUnityContainer container)
            {
                try
                {
                    var scheduler = container.Resolve<IScheduler>();
                    scheduler.Start();
    
                    IJobDetail job = JobBuilder.Create<HelloWorldJob>().Build();
    
                    ITrigger trigger = TriggerBuilder.Create()
                        .WithSimpleSchedule(x => x.WithIntervalInSeconds(20).RepeatForever())
                        .Build();
    
                    scheduler.ScheduleJob(job, trigger);
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
    
            }
        }
    }
