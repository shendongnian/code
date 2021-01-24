    public static class Extensions
    {
        public static bool IsIsbn(this string s)
        {
            if ((s?.Trim() ?? "") is string isbn)
                return s.Length == 10 /* && whatever */ ;
            return false;
        }
    }
    public class ValidIsbnToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string s)
                return s.IsIsbn();
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
    public class ValidationRuleIsbn : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return ((value as string)?.IsIsbn() ?? false)
                ? ValidationResult.ValidResult
                : new ValidationResult(false, "Must be a 10 digit number");
        }
    }
