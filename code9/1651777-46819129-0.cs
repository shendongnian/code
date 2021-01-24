    public class DataGridHelper : DependencyObject {
        public static IValueConverter GetConverter(DependencyObject obj) {
            return (IValueConverter) obj.GetValue(ConverterProperty);
        }
        public static void SetConverter(DependencyObject obj, IValueConverter value) {
            obj.SetValue(ConverterProperty, value);
        }
        public static readonly DependencyProperty ConverterProperty =
            DependencyProperty.RegisterAttached("Converter", typeof(IValueConverter), typeof(DataGridHelper), new PropertyMetadata(null, OnConverterChanged));
        private static void OnConverterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            // here we have our converter
            var converter = (IValueConverter) e.NewValue;
            // first modify binding of all existing columns if any
            foreach (var column in ((DataGrid) d).Columns.OfType<DataGridTextColumn>()) {
                if (column.Binding != null && column.Binding is Binding)
                {
                    ((Binding)column.Binding).Converter = converter;
                }
            }
            // then subscribe to columns changed event and modify binding of all added columns
            ((DataGrid) d).Columns.CollectionChanged += (sender, args) => {
                if (args.NewItems != null) {
                    foreach (var column in args.NewItems.OfType<DataGridTextColumn>()) {
                        if (column.Binding != null && column.Binding is Binding) {
                            ((Binding) column.Binding).Converter = converter;
                        }
                    }
                }
            };
        }
    }
