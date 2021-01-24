    public class MainWindowVM
    {
        private ObservableCollection<ViewList> _MyList;
        public ObservableCollection<ViewList> MyList
        {
            get { return _MyList; }
            set
            {
                if(value != null)
                {
                    _MyList = value;
                }
            }
        }
        public MainWindowVM()
        {
            _MyList = new ObservableCollection<WpfDataGridTest.ViewList>();
            _MyList.Add(new WpfDataGridTest.ViewList() { id = 1, code = "C101", description = "test1", isEnabled = true });
            _MyList.Add(new WpfDataGridTest.ViewList() { id = 2, code = "C102", description = "test2", isEnabled = false });
            _MyList.Add(new WpfDataGridTest.ViewList() { id = 3, code = "C103", description = "test3", isEnabled = true });
        }
    }
