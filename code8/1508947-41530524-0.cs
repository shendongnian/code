    public partial class MainWindow : INotifyPropertyChanged
    {        
        public MainWindow()
        { 
            DataContext = this; 
            InitializeComponent();
        }
        private ObservableCollection<string> _nursingHomeNames = new ObservableCollection<string>();
        public ObservableCollection<string> NursingHomeNames
           {
               get { return _nursingHomeNames; }
               set { _nursingHomeNames = value; }
           }
        
        public string Nursing_Home_Name //Unconventional name. But I kept your naming
        {
            get { return GetNursingHomeNameFromDB(); }
            set 
            {
                SaveNursingHomeName(value); 
                NotifyPropertyChanged("Nursing_Home_Name");
            }
        }
    }
