    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Windows.Controls;
    
    
    namespace TestWpf
    {
        class MyCustomValidationRule : ValidationRule
        {
            public string Type { get; set; }
            public override ValidationResult Validate(object p_value, CultureInfo p_cultureInfo)
            {
                switch (Type)
                {
                    case "myName":
                        string a_strValue = p_value as string;
                        if (!string.IsNullOrEmpty(a_strValue))
                        {
                            Match a_match = Regex.Match((string)p_value, @"^[a-zA-Z\d]+$");
                            return a_match.Success ? new ValidationResult(true, "Name is valid!") : new ValidationResult(false, $"Input should be a Valid Name (a-z, A-Z, 0-9)");
                        }
                        return new ValidationResult(false, "Empty name!");
                    default:
                        return new ValidationResult(false, $"UnkownValidation Parameter: " + Type);
                }
            }
        }
    }
