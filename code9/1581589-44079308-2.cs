    public class ObservableArea : GalaSoft.MvvmLight.ObservableObject
    {
        public ObservableArea()
        {
            Points = new ObservableCollection<Point>();
            Points.CollectionChanged += ( s, e ) => RaisePropertyChanged( nameof( Points ) );
        }
        public ObservableCollection<Point> Points { get; }
    }
    public class VM : INotifyPropertyChanged
    {
        private ICommand _addPointCommand;
        public ICommand AddPointCommand
        {
            get
            {
                if (_addPointCommand == null)
                {
                    _addPointCommand = new RelayCommand<MouseButtonEventArgs>(AddPoint);
                }
    
                return _addPointCommand;
            }
        }
    
        private ObservableCollection<ObservableArea> _areas { get; set; }
        public ObservableCollection<ObservableArea> Areas
        {
            get
            {
                if (_areas == null)
                {
                    _areas = new ObservableCollection<ObservableArea>();
                }
                return _areas;
            }
        }
    
        public VM()
        {
            Areas = new ObservableCollection<ObservableArea>();
            Areas.Add(new ObservableArea());
        }
    
        private void AddPoint(MouseButtonEventArgs e)
        {
            var curPoints = Areas[Areas.Count - 1];
            curPoints.Points.Add(e.GetPosition((IInputElement)e.Source));
    
            if (e.ClickCount == 2 && curMaskPoints.Count > 0)
            {
                curMaskPoints.Add(curMaskPoints[0]);
                Areas.Add(new ObservableArea());
            }
            // useless and can be removed
            // OnPropertyChanged("Areas");
        }
    
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    
    }
