    // Handle user going inactive or being reactivated
    private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        DataRowView row = dgvUsers.Rows[e.RowIndex].DataBoundItem as DataRowView;
        if (row != null && row.Row.ItemArray[7].Equals("N"))
        {
            e.CellStyle.ForeColor = Color.Gray;
        }
        else
        {
            e.CellStyle.ForeColor = Color.Black;
        }
    }
