    public class YourViewModel : BaseViewModel
    {
        public YourViewModel()
        {
            SimulateDownloadCommand = new AsyncCommand<bool>(() => SimulateDownloadAsync());
        }
        private IAsyncCommand _downloadCommand;
        public IAsyncCommand SimulateDownloadCommand
		{
			get { return _downloadCommand; }
			private set
			{
				if (_downloadCommand != value)
				{
					_downloadCommand = value;
					OnPropertyChanged("SimulateDownloadCommand");
				}
			}
		}
        async Task<bool> SimulateDownloadAsync()
		{
			await Task.Run(() => SimulateDownload());
            return true;
		}
		void SimulateDownload()
		{
			// Simulate a 1.5 second pause
			var endTime = DateTime.Now.AddSeconds(1.5);
			while (true)
			{
				if (DateTime.Now >= endTime)
				{
					break;
				}
			}
		}
    }
