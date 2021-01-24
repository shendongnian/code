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
                throw new ArgumentException("A required field must be supplied.");
            }
            else if (value is string && string.IsNullOrWhiteSpace(Convert.ToString(value)))
            {
                throw new ArgumentException("A required field must be supplied.");
            }
            else if (u != null)
            {
                if (value == null)
                {
                    throw new ArgumentException("A required field must be supplied.");
                }
                else
                {
                    _value = (T)Convert.ChangeType(value, u);
                }
            }
            else
            {
                _value = (T)Convert.ChangeType(value, t);
            }
        }
    }
