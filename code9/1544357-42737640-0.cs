	public class Worker
	{
		WeakReference<IWorkerDelegate> _workerDelegate;
		public IWorkerDelegate WorkerDelegate
		{
			get
			{
				IWorkerDelegate workerDelegate;
				return _workerDelegate.TryGetTarget(out workerDelegate) ? workerDelegate : null;
			}
			set
			{
				_workerDelegate = new WeakReference<IWorkerDelegate>(value);
			}
		}
		public async Task DoAlotOfWork()
		{
			// Do some work and continue with a delegate if assigned....
			await Task.Run(() =>
			{
				Console.WriteLine("Worker.DoAlotOfWork");
			})
			.ContinueWith((Task task) =>
			{
				if (_workerDelegate != null)
					WorkerDelegate?.PreformAdditionalWork();
			});
		}
	}
 
