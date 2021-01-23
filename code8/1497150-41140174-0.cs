    private void PopulateDataSource()
    {
        dataGridView1.DataSource = myBindingSource;
        DataRowView selectedRow;
        if (dataGridView1.SelectedRows.Count > 0)
            selectedRow = dataGridView1.SelectedRows[0] as DataRowView;
        if (selectedRow != null)
            dataGridView2.DataSource = myBindingSource2; //Set the BindingSource based on selectedRow in first Grid
    }
    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        DataRowView selectedRow;
        if (dataGridView1.SelectedRows.Count > 0)
            selectedRow = dataGridView1.SelectedRows[0] as DataRowView;
        if (selectedRow != null)
            dataGridView2.DataSource = myBindingSource2; //Set the BindingSource based on selectedRow in first Grid
    }
