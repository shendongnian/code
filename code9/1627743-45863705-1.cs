    class MainViewModel : PropertyChangedBase, IHandle<Settings>
    {
        private Settings _settings;
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;
        public MainViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _windowManager = windowManager;
        }
        public void Handle(Settings message)
        {
            _settings = message;
            // Continue here ...
        }
    }
