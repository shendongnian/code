    public class ModelWrapper<T> : NotifyDataErrorInfoBase
    {
        public T Model { get; protected set; }
        public ModelWrapper(T model)
        {
            Model = model;
        }
        public ModelWrapper()
        {
            
        }
        protected virtual TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            return (TValue)typeof(T).GetProperty(propertyName)?.GetValue(Model);
        }
        protected virtual void SetValue<TValue>(TValue value, [CallerMemberName] string propertyName = null)
        {
            typeof(T).GetProperty(propertyName)?.SetValue(Model, value);
            OnPropertyChanged(propertyName);
            ValidatePropertyInternal(propertyName, value);
        }
        private void ValidatePropertyInternal(string propertyName, object currentValue)
        {
            ClearErrors(propertyName);
            ValidateDataAnnotations(propertyName, currentValue);
            ValidateCustomErrors(propertyName);
        }
        protected virtual IEnumerable<string> ValidateProperty(string propertyName)
        {
            return null;
        }
        private void ValidateCustomErrors(string propertyName)
        {
            var errors = ValidateProperty(propertyName);
            if (errors != null)
            {
                foreach (var error in errors)
                {
                    AddError(propertyName, error);
                }
            }
        }
        private void ValidateDataAnnotations(string propertyName, object currentValue)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(Model) { MemberName = propertyName };
            Validator.TryValidateProperty(currentValue, context, results);
            foreach (var result in results)
            {
                AddError(propertyName, result.ErrorMessage);
            }
        }
    }
