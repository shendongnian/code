    public class ValueProxy
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Value
        {
            get { return Model.Get(X, Y); }
            set { Model.Set(X, Y, value); }
        }
    }
    public class MyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var x = (int)values[0];
            var y = (int)values[1];
            return new ValueProxy { X = x, Y = y };
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { Binding.DoNothing, Binding.DoNothing };
        }
    }
