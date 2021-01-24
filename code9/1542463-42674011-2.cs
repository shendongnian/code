    public partial class MyService : ServiceBase
    {
        #region Fields
        private readonly ITaskScheduler _taskScheduler;
        #endregion
        public MyService(ITaskScheduler taskScheduler)
        {
            InitializeComponent();
            _taskScheduler = taskScheduler;
        }
        protected override void OnStart(string[] args)
        {
            _taskScheduler.Run();
        }
        protected override void OnStop()
        {
            _taskScheduler.Stop();
        }
    }
