    #region MainViewModel Class
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ChildOne = new ChildOneViewModel();
            ChildTwo = new ChildTwoViewModel();
            ActiveChild = ChildOne;
            ChildOne.NextButtonClicked += (s, e) => ActiveChild = ChildTwo;
        }
        #region ActiveChild Property
        private INotifyPropertyChanged _activeChild = default(INotifyPropertyChanged);
        public INotifyPropertyChanged ActiveChild
        {
            get { return _activeChild; }
            set
            {
                if (value != _activeChild)
                {
                    _activeChild = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion ActiveChild Property
        public ChildOneViewModel ChildOne { get; private set; }
        public ChildTwoViewModel ChildTwo { get; private set; }
    }
    #endregion MainViewModel Class
    #region ChildOneViewModel Class
    public class ChildOneViewModel : ViewModelBase
    {
        public event EventHandler NextButtonClicked;
        //  You already know how to implement a command, so I'll skip that. 
        protected void NextButtonCommandMethod()
        {
            NextButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
    #endregion ChildOneViewModel Class
    #region ChildTwoViewModel Class
    public class ChildTwoViewModel : ViewModelBase
    {
    }
    #endregion ChildTwoViewModel Class
