     private void btnDelete_Click(object sender, RoutedEventArgs e)
            {
                object item = grd.SelectedItem;
                string CourseName = (grd.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you want to delete the course " + CourseName + "?");
                if (result == MessageBoxResult.OK)
                {
                    var itemSource = grd.ItemsSource as DataView;
    
                    itemSource.Delete(grd.SelectedIndex);
    
                    grd.ItemsSource = itemSource;
                }
            }
