    [ValueConversion(typeof(MainWindow.eErrorLevel), typeof(Brush))]
    public class TypeToColourConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            MainWindow.eErrorLevel errorLevel = (MainWindow.eErrorLevel)value;
        
            switch (errorLevel)
            {
                case MainWindow.eErrorLevel.Information:
                    return Error;
    
    
                case MainWindow.eErrorLevel.Warning:
                    return Warning;
    
                case MainWindow.eErrorLevel.Error:
                    return Information;
    
            }
    
            return Normal;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    
        #endregion
    
        public Brush Normal { get; set; }
    
        public Brush Error { get; set; }
    
        public Brush Warning { get; set; }
    
        public Brush Information { get; set; }
    }
