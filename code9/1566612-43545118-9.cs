    public class WarningsHandler : IDisposable
    {
        private List<WarningErrorBase> errors = null;
        // Default handler. Remember to use 'using', or otherwise you'll end up 
        // with pain and suffering!
        public void Dispose()
        {
            var errors = FetchValidationResults();
            if (errors != null && errors.Count > 0)
            {
                throw new ValidationException(errors);
            }
        }
        // Handler if you have a better idea than using an Exception
        public IEnumerable<Error> FetchValidationResults() 
        {
            var errors = this.errors;
            this.errors = null;
            return errors;
        }
        public void Warn(bool condition, Func<Warning> errorBuilder)
        {
            if (condition) 
            { 
                if (errors == null) { errors = new List<WarningErrorBase>(); }
                errors.Add(errorBuilder()); 
            }
        }
        public void Error(bool condition, Func<Error> errorBuilder)
        {
            if (condition) 
            { 
                if (errors == null) { errors = new List<WarningErrorBase>(); }
                errors.Add(errorBuilder()); 
                throw new ValidationException(FetchValidationResults());
            }
        }
    }
