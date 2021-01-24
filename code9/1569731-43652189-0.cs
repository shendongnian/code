    #if UWP
    using Windows.UI.Xaml.Data ;
    #else
    using System.Windows.Data ;
    #endif
    public class SampleValueConverter : IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter,
        #if UWP
            string language)
        {
        #else
            CultureInfo culture)
        {
            // or vice-versa if you need culture rather than language code
            var language = culture.TwoLetterISOLanguageName ;
        #endif
            ...
        }
    }
