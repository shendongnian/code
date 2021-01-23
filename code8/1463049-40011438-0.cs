    private void mgrdContentDatabase_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if(this.mgrdContentDatabase.Columns[e.ColumnIndex].HeaderText== "Size(GB)")
        {
            if (e.Value != null)
            {
                CovertFileSize(e);
            }
        }
    }
