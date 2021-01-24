     public class clsValidationRuleInteger :ValidationRule
    {
        public string strmsg;
        public bool isRequired;
        public bool? isRegex;
        bool AllowNegativeValues;
        public clsValidationRuleInteger(string strmsg, bool isRequired, bool _AllowNegativeValues)
        {
            this.strmsg = strmsg;
            this.isRequired = isRequired;
            AllowNegativeValues = _AllowNegativeValues;
        }
       public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
