    public class MainWindowViewModel : ViewModel
    {
        public ICommand Button1Command { get; }
        public ICommand Button2Command { get; }
    
        private ViewModel _currentView { get; }
        protected ViewModel FirstView { get; }
        protected ViewModel SecondView { get; }
    
        public ViewModel CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; NotifyPropertyChanged(); }
        }
    
        public MainWindowViewModel() 
        {
            this.FirstView = new FirstViewModel();
            this.SecondView= new SecondViewModel();
            this.Button1Command = new RelayCommand(OnButton1);
            this.Button2Command = new RelayCommand(OnButton2);
        }
    
        public void OnButton1()
        {
            this.CurrentView = this.FirstView;
        }
    
        public void OnButton2()
        {
            this.CurrentView = this.SecondView;
        }
    }
