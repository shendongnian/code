    public class AbbreviatedNumberConverter : TypeConverter
        {
           public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
           {
              return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
           }
         
           public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
           {
              return destinationType == typeof(InstanceDescriptor) || 
                         base.CanConvertTo(context, destinationType);
           }
         
           public override object ConvertFrom(ITypeDescriptorContext context, 
                                    CultureInfo culture, object value)
           {
              string text = value as string;
              if (text == null)
              {
                 return base.ConvertFrom(context, culture, value);
              }
         
              if (String.IsNullOrWhiteSpace(text))
              {
                 return 0.0;
              }
         
              if (culture == null)
              {
                 culture = CultureInfo.CurrentCulture;
              }
         
              double number;
              if (AbbreviatedNumeric.ValidateDouble(text, out number, culture))
                 return number;
         
              return 0.0;
           }
         
           public override object ConvertTo(ITypeDescriptorContext context, 
                             CultureInfo culture, object value, Type destinationType)
           {
              if (destinationType != null && value is Double)
              {
                 if (destinationType == typeof(string))
                 {
                    return value.ToString();
             }
              }
              return base.ConvertTo(context, culture, value, destinationType);
           }
        }
        
        public Double Amount
        {
           get { return (Double)GetValue(AmountProperty); }
           set { SetValue(AmountProperty, value); }
        }
         
        public static readonly DependencyProperty AmountProperty =
                            DependencyProperty.Register("Amount", typeof(Double), 
                            typeof(OnlineStatusControl), new PropertyMetadata(0.0));
        
        
        [TypeConverter(typeof(AbbreviatedNumberConverter))]
        public Double Amount
        {
           get { return (Double)GetValue(AmountProperty); }
           set { SetValue(AmountProperty, value); }
        }
        
        public static class AbbreviatedNumeric
        {
           public static bool ValidateDouble(string value, out double? numeric, 
                      CultureInfo cultureInfo = null)
           {
              double result;
              if(ValidateDouble(value, out result, cultureInfo))
              {
                 numeric = result;
                 return true;
              }
              numeric = null;
              return false;
           }
         
           public static bool ValidateDouble(string value, out double numeric, 
                      CultureInfo cultureInfo = null)
           {    
              if (String.IsNullOrEmpty(value))
              {
                 numeric = 0;
                 return false;
              }
         
              if (Double.TryParse(value, out numeric))
              {
                 return true;
              }
              if (value.Length > 0)
              {
                 if (cultureInfo == null)
                 {
                cultureInfo = CultureInfo.CurrentCulture;
             }
         
             NumberFormatInfo numberFormat = cultureInfo.NumberFormat;
             if (value.Substring(0, 1) == numberFormat.NumberDecimalSeparator)
             {
                value = "0" + value;
             }
             if (Double.TryParse(value.Substring(0, value.Length - 1), 
                             NumberStyles.AllowLeadingWhite | 
                             NumberStyles.AllowTrailingWhite |                      
                             NumberStyles.AllowLeadingSign |
                     NumberStyles.AllowDecimalPoint | 
                             NumberStyles.AllowThousands | 
                     NumberStyles.AllowExponent, cultureInfo, out numeric))
             {
                switch (Char.ToUpper(value[value.Length - 1]))
                {
                    case 'B':
                   numeric = numeric * 1000000000;
                   break;
                case 'M':
                   numeric = numeric * 1000000;
                   break;
                case 'K':
                   numeric = numeric * 1000;
                   break;
                default:
                   return false;
                }
                    return true;
             }
              }
              return false;
           }
        }
