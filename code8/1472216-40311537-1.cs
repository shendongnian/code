    using System;
    using System.ComponentModel;
    using System.Linq;
    namespace DataGridValidation.Entities
    {
    public class SalesFigures : IDataErrorInfo
    {
        public decimal Pie { get; set; }
        public decimal Cake { get; set; }
        public decimal Candy { get; set; }
        public decimal Chocolate { get; set; }
        public string this[ string columnName ]
        {
            get
            {
                string result = null;
                switch( columnName )
                {
                    case nameof( Pie ):
                        result = ValidateValue( nameof( Pie ), Pie );
                        break;
                    case nameof( Cake ):
                        result = ValidateValue( nameof( Cake ), Cake );
                        break;
                    case nameof( Candy ):
                        result = ValidateValue( nameof( Candy ), Candy );
                        break;
                    case nameof( Chocolate ):
                        result = ValidateValue( nameof( Chocolate ), Chocolate );
                        break;
                    default:
                        throw new ArgumentException($"{columnName} cannot be found");
                }
                return result;
            }
        }
        
        public string ValidateValue( string name, decimal value )
        {
            if( value < 0 )
            {
                return $"{name} must be greater than or equal to zero";
            }
            if( value > 10 )
            {
                return $"{name} must be equal to or less than 10";
            }
            return string.Empty;
        }
        public string Error
        {
            get
            {
                var errors = string.Empty;
                // Get all properties of object.
                var properties = TypeDescriptor.GetProperties( this );
                // Iterate through every property and look
                // for errors.
                foreach( var property in properties.Cast<PropertyDescriptor>() )
                {
                    var propertyError = this[ property.Name ];
                    if( !string.IsNullOrWhiteSpace( propertyError ) )
                    {
                        errors += $"{propertyError}{Environment.NewLine}";
                    }
                }
                return errors;
            }
        }
    }
