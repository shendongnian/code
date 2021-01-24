	public class MyRunnable : Java.Lang.Object, Java.Lang.IRunnable
	{
		readonly WeakReference<Action> actionRef;
		public MyRunnable(Action action)
		{
			actionRef = new WeakReference<Action>(action);
		}
		public void Run()
		{
			actionRef.TryGetTarget(out Action action);
			action?.Invoke();
		}
	}
