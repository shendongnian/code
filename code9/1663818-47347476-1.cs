    private void DataGridColumnHeader_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
            {
                if (((DataGridColumnHeader)sender).DisplayIndex < 2)
                {
                    return;
                }
    
                var x = DataContext as BrygadzistaViewModel;
                x.ColumnHeaderToDelete = ((DataGridColumnHeader)sender).Content.ToString();
    
                ContextMenu cm = new ContextMenu();
                MenuItem mi = new MenuItem();
                mi.Header = "Usuń";
                mi.Command = x.DeleteDay;
                cm.Items.Add(mi);
    
                cm.IsOpen = true;
            }
