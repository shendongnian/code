    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
    
                if (string.IsNullOrWhiteSpace(cell.Value?.ToString()))
                {
                    MessageBox.Show("Please enter some velue in cell");
                }
            }
