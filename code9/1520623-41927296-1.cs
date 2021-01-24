    private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (e.RowIndex < 0) return;
        var row = (sender as DataGridView).Rows[e.RowIndex];
        string value = Convert.ToString(row.Cells["Primary Onc"].Value);
        //or in VS 2015: string value = row.Cells["Primary Onc"].Value?.ToString();
        if (value == "JMK")
            row.DefaultCellStyle.BackColor = Color.Green;
        else if (value == "DBF")
            row.DefaultCellStyle.BackColor = Color.Orange;
        else
            row.DefaultCellStyle.BackColor = Color.White;
    }
