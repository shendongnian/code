        public class MainWindowViewModel: INotifyPropertyChanged
        {
        private bool _isSelectText;
        public bool IsSelectText
        {
            get
            {
                return this._isSelectText;
            }
            set
            {
                _isSelectText = value;
                OnPropertyChanged(nameof(IsSelectText));
            }
        }
        public NewSaleViewModel()
        {
        }
        #region INotifyPropertyChanged Implimentations
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        }
