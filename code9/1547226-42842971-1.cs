    public class ListViewItem : INotifyPropertyChanged
    {
        private ValueViewModel[] _values;
    
        #region Properties
    
        public ValueViewModel[] Values
        {
            get { return _values; }
            set
            {
                if (value == _values) return;
                _values = value;
                OnPropertyChanged();
            }
        }
    
        #endregion
    
        public event PropertyChangedEventHandler PropertyChanged;//[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
