    <TextBlock>
        <TextBlock.Text>
            <MultiBinding Converter="{StaticResource MultiValueConverter}">
                <Binding Path="TextView" />
                <Binding Path="TextInput" />
            </MultiBinding>
        </TextBlock.Text>
    </TextBlock>
----------
    public class NameMultiValueConverter : IMultiValueConverter
    {
        private string _textView;
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //display the value of TextView
            _textView = values[0].ToString();
            return _textView;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { _textView, /* TextInput: */ value.ToString() };
        }
    }
