    public class DepPropConverter : DependencyObject, IValueConverter
    {
        public static readonly DependencyProperty MyListProperty =
            DependencyProperty.Register(
                nameof(MyList), typeof(IList), typeof(DepPropConverter));
    
        public IList MyList
        {
            get { return (IList)GetValue(MyListProperty); }
            set { SetValue(MyListProperty, value); }
        }
    
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            //your logic here
            return value;
        }
    
        public object ConvertBack(
            object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            //your logic here
            return value;
        }
    }
