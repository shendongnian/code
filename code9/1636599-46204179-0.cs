    private void btn_down_Click(object sender, EventArgs e)
    {    
        //Make sure only one row is selected
        if (dataGridView1.SelectedRows.Count == 1)
        {
            //Get the index of the currently selected row
            int selectedIndex = dataGridView1.Rows.IndexOf(dataGridView1.SelectedRows[0]);
            
            //Increase the index and select the next row if available
            selectedIndex++;
            if (selectedIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.SelectedRows[0].Selected = false;
                dataGridView1.Rows[selectedIndex].Selected = true;
            }
        }
    }
