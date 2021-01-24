    public class RowViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public RowViewModel()
        {
            _errorFromProperty = new Dictionary<string, string>
            {
                { nameof(Fee), null },
                { nameof(Amount), null },
            };
            PropertyChanged += OnPropertyChanged;
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(Fee):
                    OnFeePropertyChanged();
                    break;
                case nameof(Amount):
                    OnAmountPropertyChanged();
                    break;
                default:
                    break;
            }
        }
        private void OnFeePropertyChanged()
        {
            if (Fee == null)
                _errorFromProperty[nameof(Fee)] = "You must select a Fee!";
            else
                _errorFromProperty[nameof(Fee)] = null;
            NotifyPropertyChanged(nameof(Amount));
        }
        private void OnAmountPropertyChanged()
        {
            if (Fee == null)
                return;
            if (Amount < Fee.Min || Amount > Fee.Max)
                _errorFromProperty[nameof(Amount)] = $"Amount must be between {Fee.Min} and {Fee.Max}!";
            else
                _errorFromProperty[nameof(Amount)] = null;
        }
        public decimal Amount
        {
            get { return _Amount; }
            set
            {
                if (_Amount != value)
                {
                    _Amount = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private decimal _Amount;
        public FeeType Fee
        {
            get { return _Fee; }
            set
            {
                if (_Fee != value)
                {
                    _Fee = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private FeeType _Fee;
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region INotifyDataErrorInfo
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public bool HasErrors
        {
            get
            {
                return _errorFromProperty.Values.Any(x => x != null);
            }
        }
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return _errorFromProperty.Values;
            else if (_errorFromProperty.ContainsKey(propertyName))
            {
                if (_errorFromProperty[propertyName] == null)
                    return null;
                else
                    return new[] { _errorFromProperty[propertyName] };
            }
            else
                return null;
        }
        private Dictionary<string, string> _errorFromProperty;
        #endregion
    }
