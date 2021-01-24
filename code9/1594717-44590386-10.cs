        public class BrushChooserConverter : IValueConverter
        {
            public Brush TrueBrush { get; set; } = Brushes.Transparent;
            public Brush FalseBrush { get; set; } = Brushes.Transparent;
            public object Convert(object value, Type targetType,
                object parameter, string language)
            {
                return System.Convert.ToBoolean(value)
                            ? TrueBrush
                            : FalseBrush;
            }
            // No need to implement converting back on a one-way binding 
            public object ConvertBack(object value, Type targetType,
                object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }
