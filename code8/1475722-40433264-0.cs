    public class MyViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyPropertyChanged();
                Validate();
            }
        }
        private string _description;
        private void Validate()
        {
            Errors[nameof(Description)].Clear();
            if (string.IsNullOrEmpty(Description))
            {
                Errors[nameof(Description)].Add("The text cannot be empty");
            }
            if (Errors[nameof(Description)].Any())
            {
                NotifyErrorsChanged(nameof(Description));
            }
        }
        public IEnumerable GetErrors(string propertyName)
            => Errors.ContainsKey(propertyName) ? Errors[propertyName] : Enumerable.Empty<string>();
        public bool HasErrors
            => Errors.Any(propertyErrors => (propertyErrors.Value ?? Enumerable.Empty<string>()).Any());
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        protected virtual void NotifyErrorsChanged([CallerMemberName] string propertyName = null)
            => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        private IDictionary<string, List<string>> Errors { get; }
            = new Dictionary<string, List<string>>
            {
                {nameof(Description), new List<string>()}
            };
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
