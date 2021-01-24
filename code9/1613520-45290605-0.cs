    private void myDataGrid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
            {
                if (e.OriginalSource == null) return;
                var row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;
                
                if (row != null)
                {
                    (this.DataContext as ViewModel).SomeViewModelMethod(row.DataContext as YourRowClass);
                }
            }
