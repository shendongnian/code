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
                    RefreshCVSView();
                }
            }
        }
		
		public ViewModel()
        {
            _cvs = new CollectionViewSource { Source = Vwr.Table.Tbl.Rows };
            CVSView.Filter = ContainsString;
        }
        
        private void RefreshCVSView()
        {
            if (CVSView.CurrentItem != null)
            {
                DataRow currentItem = (DataRow)CVSView.CurrentItem;
                CVSView.Refresh();
                if (Vwr.Table.Tbl.AsEnumerable().Count(item => item[0] == currentItem[0]) > 0)
                    CVSView.MoveCurrentTo(Vwr.Table.Tbl.AsEnumerable().First(item => item[0] == currentItem[0]));
            }
            else
            {
                CVSView.Refresh();
            }
        }
		
		private bool ContainsString(object obj)
        {
            if (string.IsNullOrEmpty(PartNumberSearchText))
                return true;
            DataRow view = obj as DataRow;
            if (view[0].ToString().ToLower().Contains(PartNumberSearchText.ToLower()))
                return true;
            return false;
        }
	}
	
