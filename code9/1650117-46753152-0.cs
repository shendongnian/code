    public class MainWindowViewModel
    {
        public  static MainWindowViewModel Instance = new MainWindowViewModel();
        public ObservableCollection<string> Contents = new ObservableCollection<string>();
        public string Location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    ReloadContents();
                }
            }
        }
        private MainWindowViewModel()
        {
        }
        private void ReloadContents()
        {
            // fill test data
            Contents.Add("Some test data.");
        }
        private string _location;
    }   
