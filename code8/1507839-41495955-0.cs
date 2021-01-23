    public class TextBoxStyleConverter : IValueConverter
    {
        public Style GloveTextBoxStyle { get; set; }
        public Style OfficeTextBoxStyle { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {    
            // analyze binded value and return needed style
            return condition ? GloveTextBoxStyle : OfficeTextBoxStyle;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
