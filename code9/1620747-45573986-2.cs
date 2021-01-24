    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
        if (cell is DataGridViewCheckBoxCell)
        {
            bool c = (bool) (cell as DataGridViewCheckBoxCell).Value;
            button1.BackColor = c ? Color.Yellow: Color.Snow;
            this.Invalidate();
        }
    }
