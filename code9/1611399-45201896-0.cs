    public class CannotBeEmptyAttribute : ValidationAttribute
    {
        private const string defaultError = "'{0}' must have at least one element.";
        public Type ListType { get; private set; }
        protected CannotBeEmptyAttribute(Type listType) : base(defaultError)
        {
            this.ListType = listType;
        }
        public override bool IsValid(object value)
        {
            object defaultValue = ListType.IsValueType ? Activator.CreateInstance(ListType) : null;
            IEnumerable list = value as IEnumerable;
            if (list != null)
            {
                foreach (var item in list)
                {
                    if(item != defaultValue)
                    {
                        return true;
                    }
                }
            }
            return false;            
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(this.ErrorMessageString, name);
        }
    }
