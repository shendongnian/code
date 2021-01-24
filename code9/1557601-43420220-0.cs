        private void dataGridMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift) & e.ChangedButton == MouseButton.Left)
            {
                DataGrid grid = e.Source as DataGrid;
                DataGridCell cell = GetParent<DataGridCell>(e.OriginalSource as DependencyObject);
                if(grid != null && cell != null && cell.IsSelected)
                {
                    e.Handled = true;
                    StartDragAndDrop(grid);
                }
            }
        }
        private T GetParent<T>(DependencyObject d) where T:class
        {
            while (d != null && !(d is T))
            {
                d = VisualTreeHelper.GetParent(d);
            }
            return d as T;
        }
        private void StartDragAndDrop(DataGrid grid)
        {
            StringBuilder sb = new StringBuilder();
            DataRow row = null;
            foreach(DataGridCellInfo ci in grid.SelectedCells)
            {
                DataRowView drv = ci.Item as DataRowView;
                string column = ci.Column.Header as string;
                if(drv != null && column != null)
                {
                    if(drv.Row != row && row != null)
                    {
                        sb.Length--;
                        sb.AppendLine();
                        row = drv.Row;
                    }
                    else if(row == null)
                    {
                        row = drv.Row;
                    }
                    sb.Append(drv[column].ToString() + "\t");
                }
            }
            if (sb.Length > 0)
            {
                sb.Length--;
                sb.AppendLine();
            }
            DragDrop.DoDragDrop(grid, sb.ToString(), DragDropEffects.Copy);
        }
