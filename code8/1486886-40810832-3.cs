        private void SelectCurrentItem(object sender, KeyboardFocusChangedEventArgs e)
        {
            ListViewItem item = (ListViewItem)sender;
            item.IsSelected = true;
            
        }
    private void Delete_Item_In_Cart_Click(object sender, RoutedEventArgs e)
    {
        try
        {   
            int index =0;
            index = list_View.SelectedIndex;
            MessageBox.Show(index.ToString());
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }  
    } 
