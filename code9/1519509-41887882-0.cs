    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CustomRequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute, IClientValidatable
    {
        public CustomRequiredAttribute()
        {
            this.ErrorMessage = "This Field is Required"; // custom error message here
        }
        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name); // expandable to format given message later
        }
    }
