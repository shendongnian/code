	public class VM
	{
		public VM()
		{
			AddItems = new DelegateCommand(() => Task.Run(()=>
				Parallel.ForEach(
					Enumerable.Range(1,1000),
					(item) => dispatcher.Invoke(() => Items.Add(item))
				))
			);
		}
		public ObservableCollection<int> Items { get; } = new ObservableCollection<int>();
		private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
		public DelegateCommand AddItems { get; }
	}
