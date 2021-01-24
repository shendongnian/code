     public void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var clickedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (clickedCell != null)
            {
                MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                string SerachId = clickedCell.ToString();
            }
    
 
