        private bool _columnWidthChanging;
        private void ColumnWidthPropertyChanged(object sender, EventArgs e)
        {
            // listen for when the mouse is released
            _columnWidthChanging = true;
            if (sender != null)
                Mouse.AddPreviewMouseUpHandler(this, BaseDataGrid_MouseLeftButtonUp);
        }
        void BaseDataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_columnWidthChanging)
            {
                _columnWidthChanging = false;
                var dgCs = FindVisualChildByName<DataGrid>(Test, "dgC");
                var dgH = FindVisualChildByName<DataGrid>(Test, "dgH").First();
                foreach (var dgC in dgCs)
                {
                    for (int i = 0; i < dgC.Columns.Count; i++)
                    {
                        var column = dgH.Columns[i];
                        dgC.Columns[i].Width = column.ActualWidth;
                    }
                }
            }
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var dgC = FindVisualChildByName<DataGrid>(Test, "dgC").First();
            var dgH = FindVisualChildByName<DataGrid>(Test, "dgH").First();
            for (int i = 0; i < dgC.Columns.Count; i++)
            {
                var column = dgC.Columns[i];
                dgH.Columns[i].Width = column.ActualWidth;
                PropertyDescriptor pd = DependencyPropertyDescriptor
                             .FromProperty(DataGridColumn.ActualWidthProperty,
                                           typeof(DataGridColumn));
                    //Add a listener for this column's width
                    pd.AddValueChanged(dgH.Columns[i],
                                       new EventHandler(ColumnWidthPropertyChanged));
            }
