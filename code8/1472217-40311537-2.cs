    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Data;
    namespace DataGridValidation.Validation
    {
    public class SalesValidationRule : ValidationRule
    {
        public override ValidationResult Validate( object value, CultureInfo cultureInfo )
        {
            var bindingGroup = ( BindingGroup )value;
            if( bindingGroup == null )
                return null;
            var errors = string.Empty;
            foreach( var item in bindingGroup.Items.OfType<IDataErrorInfo>() )
            {
                if( !string.IsNullOrWhiteSpace( item.Error ) )
                {
                    errors += $"{item.Error}{Environment.NewLine}";
                }
            }
            if( !string.IsNullOrWhiteSpace( errors ) )
            {
                return new ValidationResult( false, errors );
            }
            return ValidationResult.ValidResult;
        }
    }
