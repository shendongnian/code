    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            // Assuming that the "itmcode" field uniquely identifies an itemDB table record
            var itemCode = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            ShowEditForm(itemCode);
        }
    }
