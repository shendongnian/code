    class SelectionWrapper<TModel> : INotifyPropertyChanged
    {
        private boolean _isSelected;
        private TModel _model;
        
        public SelectionWrapper(TModel model)
        {
            Model = model;
        }
        public bool IsSelected
        {
            get { return _isSelected; }
            
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }
        public TModel Model
        {
            get { return _model; }
            
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }
        // Implement INotifyPropertyChanged ...
    }
