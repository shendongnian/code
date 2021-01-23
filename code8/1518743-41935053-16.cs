        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var dgC = FindVisualChildByName<DataGrid>(Test, "dgC");
            var dgH = FindVisualChildByName<DataGrid>(Test, "dgH");
            for (int i = 0; i < dgC.Columns.Count; i++)
            {
                dgH.Columns[i].Width = dgC.Columns[i].ActualWidth;
            }
            
        }
