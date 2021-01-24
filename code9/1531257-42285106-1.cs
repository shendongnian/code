    private void DataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
    {
        bool selected = false;
        foreach (DataGridViewCell cell in e.Cell.OwningRow.Cells)
        {
            if (cell.Selected)
            {
                selected = true;
                break;
            }
        }
        e.Cell.OwningRow.HeaderCell.Style.BackColor = selected ?
            this.dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor :
            this.dataGridView1.RowHeadersDefaultCellStyle.BackColor;
    }
