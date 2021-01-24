    public class AgeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string text = value.ToString();
            int age;
            int.TryParse(text, out age);
            if (age < 10 || age > this.Wrapper.MaxAge)
                return new ValidationResult(false, "Invalid age.");
            return ValidationResult.ValidResult;
        }
        public Wrapper Wrapper { get; set; }
    }
    public class Wrapper : DependencyObject
    {
        public static readonly DependencyProperty MaxAgeProperty =
             DependencyProperty.Register("MaxAge", typeof(int),
             typeof(Wrapper), new FrameworkPropertyMetadata(int.MaxValue));
        public int MaxAge
        {
            get { return (int)GetValue(MaxAgeProperty); }
            set { SetValue(MaxAgeProperty, value); }
        }
    }
