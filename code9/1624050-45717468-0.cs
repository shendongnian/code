    class FontSizeConverter : FrameworkElement, IMultiValueConverter
    {
        public double MaxFontSize { get; set; } = 50;
        public double MinFontSize { get; set; } = 1;
        private Size MeasureString(string candidate, Typeface typeface, double fontSize, ListView listView)
        {
            var formattedText = new FormattedText(candidate,
                                                  CultureInfo.CurrentUICulture,
                                                  FlowDirection.LeftToRight,
                                                  typeface,
                                                  fontSize,
                                                  Brushes.Black,
                                                  VisualTreeHelper.GetDpi(listView).PixelsPerDip);
            return new Size(formattedText.Width, formattedText.Height);
        }
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var containerListView = values[1] as ListView;
            if (containerListView == null || containerListView.ItemsSource==null)
            {
                return MaxFontSize;
            }
            Typeface typeface = new Typeface(containerListView.FontFamily, containerListView.FontStyle, containerListView.FontWeight, containerListView.FontStretch);
            double size = MaxFontSize;
            while (size > 0)
            {
                var biggestWidth = ((IEnumerable<string>)containerListView.ItemsSource).Select(s => MeasureString(s, typeface, size, containerListView).Width).Max();
                if (biggestWidth <= containerListView.ActualWidth)
                {
                    return size;
                }
                size--;
            }
            return MinFontSize;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
