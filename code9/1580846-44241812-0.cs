    public class SimpleDailyService : IDailyService {
        public void DailyJob() {
            var container = getJobContainer();
            using (var scope = container.BeginLifetimeScope()) {
                var scheduledTaskManager = scope.Resolve<IScheduledTaskManager>();
                scheduledTaskManager.ProcessDailyJob();
            }
        }
    
        private IContainer getJobContainer() {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new BusinessBindingsModule());
            builder.RegisterModule(new DataAccessBindingsModule());
            return builder.Build();
        }
    }
