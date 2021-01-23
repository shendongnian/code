        public ViewBViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            MainTitle = "View B";
            eventAggregator.GetEvent<UpdateEvent>().Subscribe(Updated);
        }
