	public sealed class ActionDisposable:IDisposable
	{
        //useful for making arbitrary IDisposable instances
        //that perform an Action when Dispose is called
        //(after a using block, for instance)
		private Action action;
		public ActionDisposable(Action action)
		{
			this.action = action;
		}
		public void Dispose()
		{
			var action = this.action;
			if(action != null)
			{
				action();
			}
		}
	}
