    public abstract class ViewModelBase : IDataErrorInfo, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Error => string.Join(Environment.NewLine, GetValidationErrors());
        public bool IsValid => !GetValidationErrors().Any();
        public string this[string columnName] =>
            GetValidationErrors().FirstOrDefault(result => result.MemberNames.Contains(columnName))?.ErrorMessage;
        protected IEnumerable<ValidationResult> GetValidationErrors()
        {
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(this, context, results, true);
            return results;
        }
        protected virtual void OnPropertChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertChanged(propertyName);
            return true;
        }
    }
