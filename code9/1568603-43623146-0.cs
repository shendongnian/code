    public class StringToNmeaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string sValue = (string)value;
            if (sValue == "PASHR")
            {
                {
                    return new ObservableCollection<string>()
                    {
                        "Foo",
                        "Bar",
                        "Foobar",
                        "Barfoo"
                    };
                }
            }
            if (sValue == "GPGGA")
            {
                {
                    return new ObservableCollection<string>()
                    {
                        "Oof",
                        "Rab",
                        "Raboof",
                        "Oofrab"
                    };
                }
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
