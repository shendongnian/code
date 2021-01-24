    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex != 0 && e.ColumnIndex != 1)
        {
            if (dataGridView1.Rows[e.RowIndex].Selected == false)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                selectedRows.Add(e.RowIndex);
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Selected = false;
                selectedRows.Remove(e.RowIndex);
            }
        }
        else
        {
            dataGridView1.ClearSelection();
            //Do your job here for that column/row
            foreach(int r in selectedRows)
            {
                dataGridView1.Rows[r].Selected = true;
            }
        }
    }
