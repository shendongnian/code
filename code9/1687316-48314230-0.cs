    public class MoviePresenter : ListBox
    {
        public MoviePresenter()
        {
            FrameworkElementFactory factory = new FrameworkElementFactory(typeof(UniformGrid));
            factory.SetBinding(
                UniformGrid.ColumnsProperty,
                new Binding(nameof(ActualWidth))
                {
                    Source = this,
                    Mode = BindingMode.OneWay,
                    Converter = new WidthToColumnsConverter()
                    {
                        ItemMinWidth = 100
                    }
                });
            ItemsPanel = new ItemsPanelTemplate()
            {
                VisualTree = factory
            };
        }
    }
    internal class WidthToColumnsConverter : IValueConverter
    {
        public double ItemMinWidth { get; set; } = 1;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double? actualWidth = value as double?;
            if (!actualWidth.HasValue)
                return Binding.DoNothing;
            return Math.Max(1, Math.Floor(actualWidth.Value / ItemMinWidth));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
