    internal class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Viedo> _videos;
    
        public ObservableCollection<Viedo> Videos
        {
            get
            {
                return _videos;
            }
            set
            {
                if (_videos != value)
                {
                    _videos = value;
                    OnPropertyChanged("Videos");
                }
            }
        }
    
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public ICommand DeleteCommand { set; get; }
    
        private void ExecuteDeleteCommand(object param)
        {
            int id = (Int32)param;
            Viedo cus = GetCustomerById(id);
    
            if (cus != null)
            {
                Videos.Remove(cus);
            }
        }
    
        private Viedo GetCustomerById(int id)
        {
            try
            {
                return Videos.First(x => x.Id == id);
            }
            catch
            {
                return null;
            }
        }
    
        public ViewModel()
        {
            Videos = new ObservableCollection<Viedo>();
            for (int i = 0; i < 5; i++)
            {
                Videos.Add(new Viedo());
                Videos[i].Name = "Name";
                Videos[i].Id = i;
            }
    
            this.DeleteCommand = new DelegateCommand(ExecuteDeleteCommand);
        }
    }
