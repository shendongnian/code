    public class ViewModel : INotifyDataErrorInfo
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                ValidateUsername();
            }
        }
        private void ValidateUsername()
        {
            if (_username == "valid")
            {
                if (_validationErrors.ContainsKey("Username"))
                    _validationErrors.Remove(nameof(Username));
            }
            else if (!_validationErrors.ContainsKey("Username"))
            {
                _validationErrors.Add("Username", new List<string> { "Invalid username" });
            }
            RaiseErrorsChanged("Username");
        }
        private readonly Dictionary<string, ICollection<string>>
            _validationErrors = new Dictionary<string, ICollection<string>>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private void RaiseErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)
                || !_validationErrors.ContainsKey(propertyName))
                return null;
            return _validationErrors[propertyName];
        }
        public bool HasErrors
        {
            get { return _validationErrors.Count > 0; }
        }
    }
----------
    <TextBox Text="{Binding Username, UpdateSourceTrigger=PropertyChanged, ValidatesOnNotifyDataErrors=True}" />
