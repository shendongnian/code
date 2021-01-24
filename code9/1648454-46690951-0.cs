    public class MyDataGridHelper : DependencyObject
    {
        private static readonly DependencyProperty TextColumnStyleProperty = 
            DependencyProperty.RegisterAttached("TextColumnStyle", typeof(Style), typeof(MyDataGridHelper), new PropertyMetadata
        {
            PropertyChangedCallback = (obj, e) =>
            {
                var grid = (DataGrid)obj;
                if (e.OldValue == null && e.NewValue != null)
                    grid.Columns.CollectionChanged += (obj2, e2) =>
                    {
                        UpdateColumnStyles(grid);
                    };
            }
        });
        public static void SetTextColumnStyle(DependencyObject element, Style value)
        {
            element.SetValue(TextColumnStyleProperty, value);
        }
        public static Style GetTextColumnStyle(DependencyObject element)
        {
            return (Style)element.GetValue(TextColumnStyleProperty);
        }
        private static void UpdateColumnStyles(DataGrid grid)
        {
            var style = GetTextColumnStyle(grid);
            foreach (var column in grid.Columns.OfType<DataGridTextColumn>())
                column.ElementStyle = style;
        }
    }
