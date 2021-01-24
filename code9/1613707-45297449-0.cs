    private void dgProductList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == COL_INDEX_OF_SCANQTY_COLUMN)
        {
            var sqty = (DATATYPE_OF_SCANQTY)e.Value;
            var qty = (DATATYPE_OF_QTY)dgProductList[1, e.RowIndex].Value;
    
            if (sqty != qty)
            {
                e.CellStyle.BackColor = Color.Yellow;
                e.CellStyle.ForeColor = Color.Red;
            }
            else
            {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.Black;
            }
        }
    }
