    public class MyConverter : DependencyObject, IValueConverter
    {
        private static readonly DependencyProperty ValueAProperty =
            DependencyProperty.Register("ValueA", typeof(object), typeof(MyConverter));
        public object ValueA
        {
            get { return GetValue(ValueAProperty); }
            set { SetValue(ValueAProperty, value); }
        }
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(ValueA); // or whatever
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
