	public class GmsTaskCompletion : Java.Lang.Object, IOnCompleteListener
	{
		public class GmsTaskEvent : EventArgs
		{
			public readonly Android.Gms.Tasks.Task task;
			public GmsTaskEvent(Android.Gms.Tasks.Task task) => this.task = task;
		}
		readonly EventHandler handler;
		public GmsTaskCompletion(EventHandler handler) => this.handler = handler;
		public void OnComplete(Android.Gms.Tasks.Task task)
		{
			if (handler != null)
				handler.Invoke(this, new GmsTaskEvent(task));
		}
	}
