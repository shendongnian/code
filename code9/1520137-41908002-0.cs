    private void dataGridView1_ColumnHeaderMouseClick(object sender,
                                                      DataGridViewCellMouseEventArgs e)
    {
            //some code, but do not rely on e != null
    }
    
    private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
    {
        dataGridView1_ColumnHeaderMouseClick(sender, null);
    }
