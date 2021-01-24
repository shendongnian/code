    public partial class DataBinding : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if ( PropertyChanged != null )
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    
        string text;
        public string TextString
        {
            get { return text; }
            set { text = value; NotifyPropertyChanged(); }
        }
        public DataBinding()
            : base()
        {
            InitializeComponent();
            Setupviewmodel();
            // as @Nahuel Ianni stated, he has to set DataContext to CodeBehind
            // in order to be able to get bindings work 
            DataContext = this; // <-- only if not binded before
        }
        public void Setupviewmodel() // forgot to to place () 
        // produced error : `A get or set accessor expected`
        {
            TextString = "this worked";
        }
    }
