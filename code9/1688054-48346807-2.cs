	public class ViewModel
	{
		private CollectionViewSource _cvs;
        public ICollectionView CVSView { get { return _cvs.View; } }
        private string _partNumberSearchText;
        public string PartNumberSearchText
        {
            get { return _partNumberSearchText; }
            set
            {
                if (_partNumberSearchText != value)
                {
                    _partNumberSearchText = value;
                    NotifyPropertyChanged();
                    CVSView.Refresh();
                }
            }
        }
        private ObservableCollection<string> _coll;
        public ObservableCollection<string> Coll
        {
            get { return _coll; }
            set
            {
                if (_coll != value)
                {
                    _coll = value;
                    NotifyPropertyChanged();
                }
            }
        }
		
		public ViewModel()
        {
            Coll = new ObservableCollection<string>
            {
                "String1",
                "String2",
                "String3"
            };
            _cvs = new CollectionViewSource { Source = Coll };
            CVSView.Filter = ContainsString;
        }
		
		private bool ContainsString(object obj)
        {
            if (string.IsNullOrEmpty(PartNumberSearchText))
                return true;
            if (obj.ToString().ToLower().Contains(PartNumberSearchText.ToLower()))
                return true;
            return false;
        }
	}
	
