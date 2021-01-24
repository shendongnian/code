    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Tab)
        {
            int activeRow = dataGridView1.CurrentCell.RowIndex;
            if ((activeRow + 1) < dataGridView1.RowCount)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[activeRow+1].Cells[0];
            }
        }
    }
