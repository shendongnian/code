    class ViewModelWrapper : NotifyPropertyChangedBase
    {
        private readonly dynamic _viewModel;
        public ViewModelWrapper(object viewModel)
        {
            _viewModel = viewModel;
            HasSometimes = viewModel.GetType().GetProperty("Sometimes") != null;
            _viewModel.PropertyChanged += (PropertyChangedEventHandler)_OnPropertyChanged;
        }
        private void _OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _RaisePropertyChanged(e.PropertyName);
        }
        public bool Always
        {
            get { return _viewModel.Always; }
            set { _viewModel.Always = value; }
        }
        public string OnOffAlways
        {
            get { return _viewModel.OnOffAlways; }
            set { _viewModel.OnOffAlways = value; }
        }
        public bool Sometimes
        {
            get { return HasSometimes ? _viewModel.Sometimes : false; }
            set { if (HasSometimes) _viewModel.Sometimes = value; }
        }
        public string OnOffSometimes
        {
            get { return HasSometimes ? _viewModel.OnOffSometimes : null; }
            set { if (HasSometimes) _viewModel.OnOffSometimes = value; }
        }
        private bool _hasSometimes;
        public bool HasSometimes
        {
            get { return _hasSometimes; }
            private set { _UpdateField(ref _hasSometimes, value); }
        }
    }
