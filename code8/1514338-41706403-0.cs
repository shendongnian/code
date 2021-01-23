    public class LongTask
    {
		public event EventHandler StillInProgress;
		public async Task<bool> LongRunningProcessAsync()
		{
			await Task.Delay(5000);
			OnStillInProgress(new EventArgs());
			await Task.Delay(5000);
			return true;
		}
		protected virtual void OnStillInProgress(EventArgs e)
		{
			StillInProgress?.Invoke(this, e);
		}
	}
