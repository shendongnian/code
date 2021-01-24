    public class EnforceTrueAttribute : ValidationAttribute
    {
        public EnforceTrueAttribute()
            : base("The {0} field must be true.") { }
        public override bool IsValid(object value) =>
            value is bool valueAsBool && valueAsBool;
    }
