    private void dgProductList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex >= 0 && this.dgProductList.Columns[e.ColumnIndex].Name == "scanqty")
        {
            // ...
        }
    }
