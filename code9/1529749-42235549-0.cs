    public class ViewModel : ViewModelBase
    {
        public const string TextFilterPropertyName = "TextFilter";
        private string _TextFilter;
        public string TextFilter
        {
            get
            {
                return _TextFilter;
            }
            set
            {
                if (_TextFilter == value)
                    return;
                _TextFilter = value;
                RaisePropertyChanged(TextFilterPropertyName);
                Filter();
            }
        }
        public const string MyItemListPropertyName = "MyItemList";
        private ObservableCollection<Item> _MyItemList;
        public ObservableCollection<Item> MyItemList
        {
            get
            {
                return _MyItemList;
            }
            set
            {
                if (_MyItemList == value)
                    return;
                _MyItemList = value;
                RaisePropertyChanged(MyItemListPropertyName);
            }
        }
        private ObservableCollection<Item> _filtered;
        public ObservableCollection<Item> FilteredList
        {
            get
            {
                return _filtered;
            }
            set
            {
                if (_filtered == value)
                    return;
                _filtered = value;
                RaisePropertyChanged("FilteredList");
            }
        }
        private void Filter()
        {
            _filtered.Clear();
            foreach(var item in _MyItemList)
            {
                if (item.PropertyToCheck.Contains(TextFilter))
                    _filtered.Add(item);
            }
        }
    } 
