    public class ViewModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Model.Set(X, Y, value);
            }
        }
        public ViewModel(string text)
        {
            _text = text;
        }
    }
    public class MyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var x = (int)values[0];
            var y = (int)values[1];
            return new ViewModel(Model.Get(x, y)) { X = x, Y = y };
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
