    private void grdBandControl_MouseUp(object sender, MouseEventArgs e)
    {
        foreach (DataGridViewColumn col in grdBandControl.Columns)
        {
            var columnNameWidth = ColumnNameWidths.FirstOrDefault(x => x.ColumnName == col.Name);
            if (columnNameWidth != null)
                columnNameWidth.ColumnWidth = col.Width;
            else
                ColumnNameWidths.Add(new ColumnNameWidth
                {
                    ColumnName = col.Name,
                    ColumnWidth = col.Width
                });
        }
    }
 
