    DataGridViewCell clickedCell;
    private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        try
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.ClearSelection();
                clickedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                clickedCell.Selected = true;
                var cellRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                // Show context menu with 'Copy' option
                contextMenuStrip1.Show(dataGridView1, cellRectangle.Left + e.X, cellRectangle.Top + e.Y);
            }
        }
        catch (Exception ex)
        {
            throw ex; 
        }
    }
