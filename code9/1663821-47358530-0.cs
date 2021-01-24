    [AttributeUsage(AttributeTargets.Parameter)]
    public class ArgumentAttribute : Attribute
    {
        public void Validate(string argumentName, object value)
        {
            // throw exception if not valid
        }
    }
