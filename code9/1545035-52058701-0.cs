    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    
    namespace Example.Converter
    {
        public class StringFormatConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                // object[] values per index
                // 0 ... some value 1
                // 1 ... some value 2
    
                // ... do amazing stuff with values
                return "hello world";
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                try
                {
                    // here: don't change source's "some value 1", and assign ToDecimal result to source's "some value 2"
                    return new object[] {Binding.DoNothing, System.Convert.ToDecimal(value, culture) };
                }
                catch (Exception e)
                {
                    // do not change anything in the source
                    return new object[] {Binding.DoNothing, Binding.DoNothing};
                }
            }
        }
    }
