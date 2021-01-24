    public class RequiredField<T>
    {
        private T _value;
        public RequiredField(IConvertible value)
        {
            SetValue(value);
        }
        public T GetValue()
        {
            return _value;
        }
        public void SetValue(IConvertible value)
        {
            Type t = typeof(T);
            Type u = Nullable.GetUnderlyingType(t);
            if (value == null)
            {
                // reference object is null
                throw new ArgumentException("A required field must be supplied.");
            }
            else if (value is string && string.IsNullOrWhiteSpace(Convert.ToString(value)))
            {
                // string is null or empty or whitespace
                throw new ArgumentException("A required field must be supplied.");
            }
            else if (u != null)
            {
                if (value == null)
                {
                    // Nullable object is null
                    throw new ArgumentException("A required field must be supplied.");
                }
                else
                {
                    // Nullable object has value
                    _value = (T)Convert.ChangeType(value, u);
                }
            }
            else
            {
                // value object is not null
                _value = (T)Convert.ChangeType(value, t);
            }
        }
    }
