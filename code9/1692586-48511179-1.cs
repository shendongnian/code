    public static class DataGridHelper
    {
        private static void TableDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dataGrid = d as DataGrid;
            var tableData = e.NewValue as TableData;
            if (dataGrid != null && tableData != null)
            {
                dataGrid.Columns.Clear();
                for (int i = 0; i < tableData.ColumnHeaders.Count; i++)
                {
                    DataGridColumn column = new DataGridTextColumn
                    {
                        Binding = new Binding($"Cells[{i}]"),
                        Header = tableData.ColumnHeaders[i]
                    };
                    dataGrid.Columns.Add(column);
                }
                dataGrid.ItemsSource = tableData.Rows;
            }
        }
        public static TableData GetTableData(DependencyObject obj)
        {
            return (TableData)obj.GetValue(TableDataProperty);
        }
        public static void SetTableData(DependencyObject obj, TableData value)
        {
            obj.SetValue(TableDataProperty, value);
        }
        // Using a DependencyProperty as the backing store for TableData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TableDataProperty =
            DependencyProperty.RegisterAttached("TableData", 
                typeof(TableData), 
                typeof(DataGridHelper), 
                new PropertyMetadata(null, TableDataChanged));
    }
