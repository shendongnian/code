    public class TaxBefore_Sum : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new  PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<Staff> staff_show = new ObservableCollection<Staff>();
        public ObservableCollection<Staff> Staff_Show
        {
         get { return staff_show;}
         set { staff_show = value; this.OnPropertyChanged("Staff_Show");
        }
        public Taxbefore_Sum(ObservableCollection<Staff> StaffAccept)
        {
             InitializeComponent();
             this.DataContext = this;
             Staff_Show = StaffAccept;
        }
 
    }
