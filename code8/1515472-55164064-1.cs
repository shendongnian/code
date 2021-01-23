    private void DataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
        {
            if (row.IsNewRow)
            {
                dataGridView1.ClearSelection();
                return;
            }
        }
    }
