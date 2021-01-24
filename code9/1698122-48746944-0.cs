    private void BtnDelete_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridUsers.SelectedItem == null)
        {
            MessageBox.Show("There is no selected rows!");// show a message here to inform
        }
        else
        {
            DataView dataView = DataGridUsers.ItemsSource as DataView;
            if (dataView != null)
            {
                for (int i = DataGridUsers.SelectedItems.Count - 1; i >= 0; i--)
                {
                    DataRowView drv = DataGridUsers.SelectedItems[i] as DataRowView;
                    if (drv != null)
                    {
                        dataView.Table.Rows.Remove(drv.Row);
                    }
                }
            }
        }
    }
