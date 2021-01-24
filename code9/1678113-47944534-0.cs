    private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (this.dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
        {
            this.dataGridView1.EndEdit();
        }
    }
