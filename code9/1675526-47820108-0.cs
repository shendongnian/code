    namespace UpdateEnvironmentService
    {
    	public partial class Scheduler : ServiceBase
    	{
    		private readonly CancellationTokenSource _tcs;
    		public Scheduler()
    		{
    			InitializeComponent();
    			_tcs = new CancellationTokenSource();
    		}
    
    		protected override void OnStart(string[] args)
    		{
    			Library.WriteLog("Data Updater Started ");
    			Task.Factory.StartNew(Runner, _tcs.Token);
    		}
    		
    		private async void Runner()
    		{
    			Library.WriteLog("In runner");
    			var delay = TimeSpan.FromSeconds(1);
    			while(!_tcs.IsCancellationRequested)
    			{
    				Library.WriteLog("Waiting...");
    				await Task.Delay(delay, _tcs.Token);
    				UpdateData();
    			}
    			Library.WriteLog("Cancellation requested; exiting runner");
    		}
    
    		private void UpdateData()
    		{
    			Library.WriteLog("Got to update Data ");
    		}
    
    		protected override void OnStop()
    		{
    			_tcs.Cancel();
    			Library.WriteLog("Data Updater Stopped ");
    		}
    	}
    }
