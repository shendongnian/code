        public class BrushChooserConverter : IValueConverter
        {
            public Brush TrueBrush { get; set; }
            public Brush FalseBrush { get; set; }
            private Brush _transparentBrush = new SolidColorBrush(Colors.Transparent);
            public object Convert(object value, Type targetType,
                object parameter, string language)
            {
                var rtn = System.Convert.ToBoolean(value)
                            ? TrueBrush
                            : FalseBrush;
                return rtn ?? _transparentBrush;
            }
            // No need to implement converting back on a one-way binding 
            public object ConvertBack(object value, Type targetType,
                object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }
