    private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        DataGridView dgv = sender as DataGridView;
        if (dgv.Columns[e.ColumnIndex].Name.Equals("Gender"))
        {
            if (e.Value != null && e.Value.ToString().Trim() == "Male")
            {
                dgv.Rows[e.RowIndex].Cells["name"].Style.BackColor = Color.White;
            }
            else
            {
                dgv.Rows[e.RowIndex].Cells["name"].Style.BackColor = Color.DarkGray;
            }
        }
    }
