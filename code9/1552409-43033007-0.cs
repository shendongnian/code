    ComboBox cmb = (ComboBox)sender;
    cmb.SelectionChanged += cmbx_SelectionChanged;
    void cmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        MessageBox.Show(string.Format("Index has been changed {0}", yourcomobobox.SelectedIndex));
     if(yourcomobobox.SelectedIndex==1)
      {
       foreach (string item in izbira1){ 
       listview.Items.Add(item);
       }
      }
    }
