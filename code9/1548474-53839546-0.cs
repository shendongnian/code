    private void GotFocus(object sender, RoutedEventArgs e)
            {
                var sen = sender as DataGrid;
                DataGridCell cell = e.OriginalSource as DataGridCell;
                if (cell != null && cell.Column is DataGridCheckBoxColumn)
                {
                    sen.BeginEdit();
                    CheckBox chkBox = cell.Content as CheckBox;
                    if (chkBox != null)
                    {
                        chkBox.IsChecked = !chkBox.IsChecked;
                    }
                }
            }
