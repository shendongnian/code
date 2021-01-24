    public class TableController : INotifyPropertyChanged
    {
        private IList<entry> _allEntries;
        private ObservableCollection<entry> _filteredEntries = new ObservableCollection<entry>();
        public IList<entry> AllEntries
        {
            get
            {
                return _allEntries;
            }
            set
            {
                _allEntries = value;
                NotifyPropertyChanged("AllEntries");
            }
        }
        public ObservableCollection<entry> FilteredEntries
        {
            get
            {
                return _filteredEntries;
            }
            set
            {
                _filteredEntries = value;
                NotifyPropertyChanged("FilteredEntries");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void LoadData()
        {
            using (var dbContext = new InventarDBEntities())
            {
                AllEntries = dbContext.entry.OrderBy(x => x.name).ToList();
                //FilteredEntries = new BindingList<entry>(AllEntries);
            }
        }
        public void TestMethod()
        {
            foreach (entry entry in AllEntries)
            {
                FilteredEntries.Add(entry);
            }
        }
    }
