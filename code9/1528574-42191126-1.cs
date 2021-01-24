    public class MyViewModel : ViewModelBase, IHandleMessages<CarMoved>
    {
        private readonly object _lock = new object();
        public ObservableCollection<CarData> Cars = new ObservableCollection<CarData>();
        public MyViewModel()
        {
            Application.Current.Dispatcher.Invoke(() => BindingOperations.EnableCollectionSynchronization(Cars, _lock));
        }
        public Task Handle(CarMoved message, IMessageHandlerContext context)
        {
            Cars.Add(new Car());
            return Task.CompletedTask;
        }
    }
