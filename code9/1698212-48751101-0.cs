    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            ...
            dataTable.RowChanged += (ss, ee) => 
            {
                //invoke the getter of the FilteredMain
                NotifyPropertyChanged("FilteredMain");
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        ...
    }
