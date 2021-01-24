    [Service(Label = "TaskEndService")]
    [IntentFilter(new String[] { "com.sushihangover.TaskEndService" })]
    public class TaskEndService : Service
    {
        IBinder binder;
        public override StartCommandResult OnStartCommand(Android.Content.Intent intent, StartCommandFlags flags, int startId)
        {
            return StartCommandResult.NotSticky;
        }
        public override IBinder OnBind(Intent intent)
        {
            binder = new TaskEndServiceBinder(this);
            return binder;
        }
		public override void OnTaskRemoved(Intent rootIntent)
		{
			Log.Info("SO", $"{GetType().Name} just got killed....");
			base.OnTaskRemoved(rootIntent);
		}
    }
    public class TaskEndServiceBinder : Binder
    {
        readonly TaskEndService service;
        public TaskEndServiceBinder(TaskEndService service)
        {
            this.service = service;
        }
        public TaskEndService GetTaskEndService()
        {
            return service;
        }
    }
