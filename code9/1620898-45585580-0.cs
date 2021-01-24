    public class ViewModelA : IHandle<string>
    {
        private readonly IEventAggregator _eventAggregator;
        public ViewModelA(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }
        public void Handle(string message)
        {
            MessageBox.Show(message);
        }
    }
