	public class DownloadCompleteReceiver : BroadcastReceiver
	{
		long id;
		EventHandler handler;
		public DownloadCompleteReceiver(long id, EventHandler handler)
		{
			this.id = id;
			this.handler = handler;
		}
		public override void OnReceive(Context context, Intent intent)
		{
			if (intent.Action == DownloadManager.ActionDownloadComplete &&
				 id == intent.GetLongExtra(DownloadManager.ExtraDownloadId, 0))
			{
				handler.Invoke(this, EventArgs.Empty);
			}
		}
	}
