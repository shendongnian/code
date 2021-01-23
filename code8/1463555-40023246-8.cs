    public class ViewModelbase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class MyViewModel : ViewModelbase
    {
        public MyViewModel()
        {
            //  I populated my DataTable with "Row 1", "Row 2", etc.
            //  Naturally you'd use a value from your own data. 
            SelectedColumnValue = "Row 2";
        }
        #region SelectedColumnValue Property
        private String _selectedColumnValue = default(String);
        public String SelectedColumnValue
        {
            get { return _selectedColumnValue; }
            set
            {
                if (value != _selectedColumnValue)
                {
                    _selectedColumnValue = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion SelectedColumnValue Property
        public DataTable Data { get; protected set; }
    }
