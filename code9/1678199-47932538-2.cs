    using System;
    using System.Linq;
    using System.Windows.Data;
    using System.Windows.Markup;
    
    namespace WpfApplication1
    {
        public class ComparisonConverter : MarkupExtension, IMultiValueConverter
        {
            public ComparisonConverter()
            {
            }
    
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                string result = null;
                if (values.Count() >= 2)
                {
                    int value1 = System.Convert.ToInt32(values[0]);
                    int value2 = System.Convert.ToInt32(values[1]);
    
                    if (value1 > value2)
                    {
                        result = "GT";
                    }
                    else if (value1 < value2)
                    {
                        result = "LT";
                    }
                    else
                    {
                        result = "EQ";
                    }
                }
    
                return result;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return this;
            }
        }
    }
