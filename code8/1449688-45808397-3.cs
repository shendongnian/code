        public ViewBViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            MainTitle = "View B";
            eventAggregator.GetEvent<UpdateTitleEvent>().Subscribe(Updated);
        }
