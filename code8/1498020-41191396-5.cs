    private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        ulong value;
        if (ulong.TryParse(e.Value?.ToString(), out value))
        {
            e.Value = string.Format("{0:n0}", value);
        }
    }
