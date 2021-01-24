    private void lbxManagerDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        MTBL_DataContainer selected = lbxManagerDisplay.SelectedItem as MTBL_DataContainer;
        if (selected != null)
        {
            txtblock_ManagerName.Text = selected.ID.ToString();
        }
    }
