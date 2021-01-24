    public sealed class MatchingSupervisor
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(MatchingSupervisor));
		private readonly IHubContext _hub;
		private readonly Timer _timer;
		#region Singleton
		public static MatchingSupervisor Instance => SupervisorInstance.Value;
		// Lazy initialization to ensure SupervisorInstance creation is threadsafe
		private static readonly Lazy<MatchingSupervisor> SupervisorInstance = new Lazy<MatchingSupervisor>(() => 
				new MatchingSupervisor(GlobalHost.ConnectionManager.GetHubContext<YourHubClass>()));
		private MatchingSupervisor(IHubContext hubContext)
		{
			_hub = hubContext;
			_timer = new Timer(Run, null, 0, Timeout.Infinite);
		}
		#endregion
		private async void Run(object state)
		{
			// TODO send messages to clients
		}
    }
