	public class WorkerState
	{
		private Worker currentWorker = null;
		private Subject<Worker> currentWorkerSubject = new Subject<Worker>();
		public Worker CurrentWorker
		{
			set
			{
				currentWorker = value;
				currentWorkerSubject.OnNext(value);
			}
		}
	
		public IObservable<Worker> WorkerIsBusy
		{
			get =>
				currentWorkerSubject
					.StartWith(currentWorker)
					.Where(w => w != null)
					.Select(w => w.IsWorking)
					.Switch();
		}
	}
