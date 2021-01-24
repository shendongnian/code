    private void menuListBox_SelectedValueChanged(object sender, EventArgs e) //this is the code when I select an item on the listview, then appears at the textbox
    {        
        foreach (DataGridViewRow row in menuDataGrid.Rows)
        {
            if (row.Cells[3].Value.ToString().Equals(menuListBox.SelectedItem.ToString()))
            {
                pricetxtbox.Text = row.Cells[4].Value.ToString();
                break;
            }
        }
    }
