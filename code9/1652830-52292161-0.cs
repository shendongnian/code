    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    
    namespace Admin.Validators
    {
        public class Html5RangeAttribute : ValidationAttribute, IClientModelValidator
        {
            private  string _max;
            private  string _min;
            
            private object Minimum { get;  set; }
            private object Maximum { get;  set; }
            
            private Type OperandType { get; }
            private bool ParseLimitsInInvariantCulture { get; set; }
            private bool ConvertValueInInvariantCulture { get; set; }
            
            public Html5RangeAttribute(int minimum, int maximum)
            {
                Minimum = minimum;
                Maximum = maximum;
                OperandType = typeof(int);
            }
            
            public Html5RangeAttribute(double minimum, double maximum)
            {
                Minimum = minimum;
                Maximum = maximum;
                OperandType = typeof(double);
            }
            
            public Html5RangeAttribute(Type type, string minimum, string maximum)
            {
                OperandType = type;
                Minimum = minimum;
                Maximum = maximum;
            }       
            
            private Func<object, object> Conversion { get; set; }
            
            private void Initialize(IComparable minimum, IComparable maximum, Func<object, object> conversion)
            {
                if (minimum.CompareTo(maximum) > 0)
                {
                    throw new InvalidOperationException(string.Format("The maximum value '{0}' must be greater than or equal to the minimum value '{1}'.", maximum, minimum));
                }
    
                Minimum = minimum;
                Maximum = maximum;
                Conversion = conversion;
            }
            
            public override bool IsValid(object value)
            {            
                SetupConversion();
                
                if (value == null || (value as string)?.Length == 0)
                {
                    return true;
                }
    
                object convertedValue;
    
                try
                {
                    convertedValue = Conversion(value);
                }
                catch (FormatException)
                {
                    return false;
                }
                catch (InvalidCastException)
                {
                    return false;
                }
                catch (NotSupportedException)
                {
                    return false;
                }
    
                var min = (IComparable)Minimum;
                var max = (IComparable)Maximum;
                return min.CompareTo(convertedValue) <= 0 && max.CompareTo(convertedValue) >= 0;
            }
            
            public override string FormatErrorMessage(string name)
            {
                SetupConversion();
    
                return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, Minimum, Maximum);
            }
    
            private void SetupConversion()
            {
                if (Conversion == null)
                {
                    object minimum = Minimum;
                    object maximum = Maximum;
    
                    if (minimum == null || maximum == null)
                    {
                        throw new InvalidOperationException("The minimum and maximum values must be set.");
                    }
    
                    // Careful here -- OperandType could be int or double if they used the long form of the ctor.
                    // But the min and max would still be strings.  Do use the type of the min/max operands to condition
                    // the following code.
                    Type operandType = minimum.GetType();
    
                    if (operandType == typeof(int))
                    {
                        Initialize((int) minimum, (int) maximum, v => Convert.ToInt32(v, CultureInfo.InvariantCulture));
                    }
                    else if (operandType == typeof(double))
                    {
                        Initialize((double) minimum, (double) maximum,
                            v => Convert.ToDouble(v, CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        Type type = OperandType;
                        if (type == null)
                        {
                            throw new InvalidOperationException("The OperandType must be set when strings are used for minimum and maximum values.");
                        }
    
                        Type comparableType = typeof(IComparable);
                        if (!comparableType.IsAssignableFrom(type))
                        {
                            throw new InvalidOperationException(string.Format("The type {0} must implement {1}.",
                                type.FullName,
                                comparableType.FullName));
                        }
    
                        TypeConverter converter = TypeDescriptor.GetConverter(type);
                        IComparable min = (IComparable) (ParseLimitsInInvariantCulture
                            ? converter.ConvertFromInvariantString((string) minimum)
                            : converter.ConvertFromString((string) minimum));
                        IComparable max = (IComparable) (ParseLimitsInInvariantCulture
                            ? converter.ConvertFromInvariantString((string) maximum)
                            : converter.ConvertFromString((string) maximum));
    
                        Func<object, object> conversion;
                        if (ConvertValueInInvariantCulture)
                        {
                            conversion = value => value.GetType() == type
                                ? value
                                : converter.ConvertFrom(null, CultureInfo.InvariantCulture, value);
                        }
                        else
                        {
                            conversion = value => value.GetType() == type ? value : converter.ConvertFrom(value);
                        }
    
                        Initialize(min, max, conversion);
                    }
                }
            }
    
            public  void AddValidation(ClientModelValidationContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }
                
                _max = Convert.ToString(Maximum, CultureInfo.InvariantCulture);
                _min = Convert.ToString(Minimum, CultureInfo.InvariantCulture);
    
                MergeAttribute(context.Attributes, "data-val", "false");
                MergeAttribute(context.Attributes, "data-val-range", GetErrorMessage(context));
                MergeAttribute(context.Attributes, "data-val-range-max", _max);
                MergeAttribute(context.Attributes, "data-val-range-min", _min);
                MergeAttribute(context.Attributes, "min", _min);
                MergeAttribute(context.Attributes, "max", _max);
            }
                   
            private static  bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
            {
                if (attributes.ContainsKey(key))
                {
                    return false;
                }
    
                attributes.Add(key, value);
                return true;
            }
            
            private string GetErrorMessage(ModelValidationContextBase validationContext)
            {
                if (validationContext == null)
                {
                    throw new ArgumentNullException(nameof(validationContext));
                }
    
                return string.Format("The field {0} must be between {1} and {2}.", validationContext.ModelMetadata.GetDisplayName(), Minimum, Maximum );
            }
        }
        }
