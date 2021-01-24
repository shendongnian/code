            // Get the clicked MenuItem
            MenuItem menuItem = (MenuItem)sender;
            //Get the ContextMenu to which the menuItem belongs
            ContextMenu contextMenu = (ContextMenu)menuItem.Parent;
            //Find the placementTarget
            DataGridCell cellItem = (DataGridCell)contextMenu.PlacementTarget;
            
            DataGridColumn col = cellItem.Column;
            int index = Grid.Columns.IndexOf(col);
                        
            DataRowView dr = (DataRowView)cellItem.DataContext;
            DataRow row = dr.Row;
            string value = dr.Row.ItemArray[index].ToString();
            string column = col.Header.ToString();
            Console.WriteLine(value);
            Console.WriteLine(column);
