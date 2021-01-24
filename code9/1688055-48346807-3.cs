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
		
		public ViewModel()
        {
            _cvs = new CollectionViewSource { Source = Vwr.Table.Tbl.Rows };
            CVSView.Filter = ContainsString;
			// We will override PartNumberSearchText when an item is selected
            CVSView.CurrentChanged += CVSView_CurrentChanged;
        }
        private void CVSView_CurrentChanged(object sender, System.EventArgs e)
        {
			// The current item will be lost when the view is refreshed "CVSView.Refresh();", so we need
			// to set it again after this change
			
			// Store the current item
            DataRow currentItem = (DataRow)CVSView.CurrentItem;
			// This call will refresh the view and the current item will be lost
            if (CVSView.CurrentItem != null)
                PartNumberSearchText = ((DataRow)CVSView.CurrentItem)[0].ToString();
			// Restore the current item based on a unique identifier (in this case the value in the first column)
            if (Vwr.Table.Tbl.AsEnumerable().Count(item => item[0] == currentItem[0]) > 0)
                CVSView.MoveCurrentTo(Vwr.Table.Tbl.AsEnumerable().First(item => item[0] == currentItem[0]));
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
	
