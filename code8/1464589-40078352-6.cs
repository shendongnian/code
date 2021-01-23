	void Main()
	{
		var schedulerProvider = new TestSchedulerProvider();
	
		var cachedData = Enumerable.Range(0,3).Select(i => new TestDepartament
		{
			Name = $"Departament {i}",
			ImageUrl = $"departament_{i}_image_url",
			ContentUrl = $"departament_{i}_content_url",
		}).ToArray();
	
		var liveData = Enumerable.Range(10, 5).Select(i => new TestDepartament
		{
			Name = $"Departament {i}",
			ImageUrl = $"departament_{i}_image_url",
			ContentUrl = $"departament_{i}_content_url",
		}).ToArray();
	
		var data = schedulerProvider.Background.CreateColdObservable<IEnumerable<TestDepartament>>(
			ReactiveTest.OnNext<IEnumerable<TestDepartament>>(100, cachedData),
			ReactiveTest.OnNext<IEnumerable<TestDepartament>>(3000, liveData),
			ReactiveTest.OnCompleted<IEnumerable<TestDepartament>>(3000));
		
		var dataService = Substitute.For<ITestDataService>();
		dataService.GetDepartaments().Returns(data);
		
		var viewModel = new TestViewModel(dataService, schedulerProvider);
		
		Assert.Equal(AsyncState.Idle, viewModel.State);
		
		viewModel.RefreshItems();
		Assert.Equal(AsyncState.Processing, viewModel.State);
		
		schedulerProvider.Background.AdvanceTo(110);
		schedulerProvider.Foreground.Start();
	
		Assert.Equal(cachedData, viewModel.Departments);
	
		schedulerProvider.Background.Start();
		schedulerProvider.Foreground.Start();
		
		Assert.Equal(liveData, viewModel.Departments);
		Assert.Equal(AsyncState.Idle, viewModel.State);
	}
	
	// Define other methods and classes here
	public class TestViewModel : INotifyPropertyChanged, IDisposable
	{
		private readonly ITestDataService _dataService;
		private readonly ISchedulerProvider _schedulerProvider;
		private readonly SerialDisposable _refreshSubscription = new SerialDisposable();
		private AsyncState _state = AsyncState.Idle;
		
		public ObservableCollection<TestDepartament> Departments { get;} = new ObservableCollection<UserQuery.TestDepartament>();
		public AsyncState State
		{
			get { return _state; }
			set
			{
				_state = value;
				OnPropertyChanged(nameof(State));
			}
		}
	
	
		public TestViewModel(ITestDataService dataService, ISchedulerProvider schedulerProvider)
		{
			_dataService = dataService;
			_schedulerProvider = schedulerProvider;
		}
	
		public void RefreshItems()
		{
			Departments.Clear();
			State = AsyncState.Processing;
			_refreshSubscription.Disposable = _dataService.GetDepartaments()
				.SubscribeOn(_schedulerProvider.Background)
				.ObserveOn(_schedulerProvider.Foreground)
				.Subscribe(
					items =>
					{
						Departments.Clear();
						foreach (var item in items)
						{
							Departments.Add(item);	
						}
	                },
					ex => State = AsyncState.Faulted(ex.Message),
					() => State = AsyncState.Idle);
		}
	
		#region INotifyPropertyChanged implementation
	
		public event PropertyChangedEventHandler PropertyChanged;
	
		private void OnPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	
		#endregion
		
		public void Dispose()
		{
			_refreshSubscription.Dispose();
		}
	}
	
	public interface ITestDataService
	{
		IObservable<IEnumerable<TestDepartament>> GetDepartaments();
	}
		
	public interface ISchedulerProvider
	{
		IScheduler Foreground { get;}
		IScheduler Background { get;}
	}
	public class TestSchedulerProvider : ISchedulerProvider
	{
		public TestSchedulerProvider()
		{
			Foreground = new TestScheduler();
			Background = new TestScheduler();
		}
		IScheduler ISchedulerProvider.Foreground { get { return Foreground; } }
		IScheduler ISchedulerProvider.Background { get { return Background;} }
		public TestScheduler Foreground { get;}
		public TestScheduler Background { get;}
	}
	public sealed class AsyncState
	{
		public static readonly AsyncState Idle = new AsyncState(false, null);
		public static readonly AsyncState Processing = new AsyncState(true, null);
		
		private AsyncState(bool isProcessing, string errorMessage)
		{
			IsProcessing = isProcessing;
			IsFaulted = string.IsNullOrEmpty(errorMessage);
			ErrorMessage = ErrorMessage;
		}
		
		public static AsyncState Faulted(string errorMessage)
		{
			if(string.IsNullOrEmpty(errorMessage))
				throw new ArgumentException();
			return new AsyncState(false, errorMessage);
		}
		
		public bool IsProcessing { get; }
		public bool IsFaulted { get; }
		public string ErrorMessage { get; }
	}
	
	public class TestDepartament
	{
		public string ContentUrl { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }
	}
