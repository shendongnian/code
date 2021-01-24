    public class WarningsHandler : IDisposable
    {
        private List<Warning> errors = null;
        public void Dispose()
        {
            var errors = this.errors;
            this.errors = null;
            if (errors != null && errors.Count > 0)
            {
                throw new ValidationException(errors);
            }
        }
        public void Validate(bool condition, Func<Warning> errorBuilder)
        {
            if (condition) 
            { 
                if (errors == null) { errors = new List<Warning>(); }
                errors.Add(errorBuilder()); 
            }
        }
    }
