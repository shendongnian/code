    public class NotNullValidationRule : ValidationRule
    {
      public override ValidationResult Validate(object value, CultureInfo cultureInfo)
      {
    
       if ((bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue)) 
        {
            return ValidationResult.ValidResult;
        }
    
        string str = value as string;
    
        return string.IsNullOrEmpty(str) ? new ValidationResult(false, Application.Current.FindResource("EmptyStringNotAllowed")) : ValidationResult.ValidResult;
      }
    }
