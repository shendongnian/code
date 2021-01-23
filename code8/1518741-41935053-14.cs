        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var dg = FindVisualChildByName<DataGrid>(Test, "dgC");
            assets.Col1Width = dg.Columns[0].ActualWidth;
            assets.Col2Width = dg.Columns[1].ActualWidth;
            
        }
