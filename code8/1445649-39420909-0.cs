    private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 1) // specify the desired column number
        {
            string value = e.Value.ToString();
            if (value == "Not Paid")
                e.CellStyle.BackColor = Color.Red;
            else if (value == "In Progress")
                e.CellStyle.BackColor = Color.Yellow;
        }
    }
