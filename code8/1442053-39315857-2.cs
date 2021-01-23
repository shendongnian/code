    public static class DataGridColumnsBehavior
    {
        public static readonly DependencyProperty
            FlipHeaderProperty =
                DependencyProperty.RegisterAttached("FlipHeader",
                    typeof(bool), typeof(DataGridColumnsBehavior),
                        new PropertyMetadata(FlipHeaderChanged));
        public static bool GetFlipHeader(DependencyObject obj)
        {
            return (bool)obj.GetValue(FlipHeaderProperty);
        }
        public static void SetFlipHeader(DependencyObject obj, bool value)
        {
            obj.SetValue(FlipHeaderProperty, value);
        }
        private static void FlipHeaderChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs args)
        {
            var grid = d as DataGrid;
            var flip = (bool)grid.GetValue(FlipHeaderProperty);
            if (grid == null
             || grid.Columns.Count == 0
             || flip == false) return;
            foreach (var column in grid.Columns)
            {
                if (column.GetType() == typeof(DataGridCheckBoxColumn))
                    column.HeaderStyle = 
                        (Style)grid.FindResource("CheckBoxColumnHeaderStyle");
            }
        }
    }
