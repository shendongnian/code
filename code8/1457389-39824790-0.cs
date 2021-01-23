       <DataGrid.CellStyle>
          <Style TargetType="DataGridCell">
              <EventSetter Event="Loaded" Handler="DataGridCell_Loaded"/>
          </Style>
       </DataGrid.CellStyle>
        void DataGridCell_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            DependencyObject reference = cell;
            while (reference.GetType() != typeof(DataGridRow))
                reference = VisualTreeHelper.GetParent(reference);
            DataGridRow row = reference as DataGridRow;
            while (reference.GetType() != typeof(DataGrid))
                reference = VisualTreeHelper.GetParent(reference);
            DataGrid grid = reference as DataGrid;
            FrameworkElement elem = grid.Columns[2].GetCellContent(row);
            // use elem.DataContext, or traverse elem's visualtree to do something
            // code below is just an example
            if (elem is TextBlock)
            {
                System.Diagnostics.Debug.WriteLine((elem as TextBlock).Text);
                if ((elem as TextBlock).Text == "34")
                    cell.Background = Brushes.DarkMagenta;
            }
        }
