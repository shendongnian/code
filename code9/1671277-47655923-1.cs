    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            BillAddress = new Address();
            DelAddress = new Address();
        }
        private Address _billAddress = null;
        public Address BillAddress
        {
            get { return _billAddress; }
            set
            {
                if (value != _billAddress)
                {
                    _billAddress = value;
                    OnPropertyChanged();
                }
            }
        }
        private Address _delAddress = null;
        public Address DelAddress
        {
            get { return _delAddress; }
            set
            {
                if (value != _delAddress)
                {
                    _delAddress = value;
                    OnPropertyChanged();
                }
            }
        }
    }
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        #endregion INotifyPropertyChanged
    }
