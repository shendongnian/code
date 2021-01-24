    public class Company : INotifyDataErrorInfo
    {
        private readonly Dictionary<string, string> _validationErrors = new Dictionary<string, string>();
        public Company()
        {
            //validate immediately:
            ValidateName();
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                ValidateName();
            }
        }
        public void ValidateName()
        {
            if (string.IsNullOrEmpty(_name))
                _validationErrors["Name"] = "cannot be empty...";
            else
                _validationErrors.Remove("Name");
            RaiseErrorsChanged("Name");
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private void RaiseErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !_validationErrors.ContainsKey(propertyName))
                return null;
            return new List<string>(1) { _validationErrors[propertyName] };
        }
        public bool HasErrors
        {
            get { return _validationErrors.Count > 0; }
        }
    }
