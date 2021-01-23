    foreach (DataGridViewRow row in this.dataGridView1.Rows)
    {
        double value1;
        double value2;
        if(!double.TryParse(row.Cells[3].Value.ToString(), out value1) || !double.TryParse(row.Cells[4].Value.ToString(), out value2)
        {
            // throw exception or other handling here for unexcepted values in cells
        }
        else (value1 >  value2)
        {
            row.Cells[3].Style.BackColor = Color.PaleGreen;
        }
