       public class BuggyViewModel : MvxViewModel, INotifyPropertyChanged
       {
            public event PropertyChangedEventHandler PropertyChanged;
            private Random _random;
    
            string  _BuggyTitle { get; set; }
    
            public string BuggyTitle
            {
                get { return _BuggyTitle; }
                set { _BuggyTitle = value; RaisePropertyChanged(() => 
                       BuggyTitle); }
            }
    
            public BuggyViewModel()
            {
                _random = new Random();
            }
    
            public override void Start()
            {
                base.Start();
                BuggyTitle = "" + _random.Next(1000);
            }
        
        
            protected void OnPropertyChanged(string propertyName)
            {
               var handler = PropertyChanged;
               if (handler != null)
                  handler(this, new PropertyChangedEventArgs(propertyName));
            }
       }
