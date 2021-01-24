    public class MainViewModel:INotifyPropertyChanged  //Look into using Prism and BindableBase instead of INotifyPropertyChanged
    {
        private BlueViewModel blueVM;
        private OrangeViewModel orangeVM;
        private RedViewModel redVM;
        public event PropertyChangedEventHandler PropertyChanged=delegate { };
        object selectedView;
        public object SelectedView
        {
            get { return selectedView; }
            private set
            {
                selectedView = value;
                RaisePropertyChanged("SelectedView");
            }
        }
        public ICommand SelectBlueViewCommand { get; private set; }
        public ICommand SelectOrangeViewCommand { get; private set; }
        public ICommand SelectRedViewCommand { get; private set; }
        public MainViewModel()
        {
            blueVM = new BlueViewModel();
            orangeVM = new OrangeViewModel();
            redVM = new RedViewModel();
            SelectBlueViewCommand = new RelayCommand(() => SelectedView = blueVM);
            SelectOrangeViewCommand = new RelayCommand(() => SelectedView = orangeVM);
            SelectRedViewCommand = new RelayCommand(() => SelectedView = redVM);
        }
        void RaisePropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
