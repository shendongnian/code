    private void CustInvLines_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
            var column = CustInvLines.Columns[e.ColumnIndex];
            if (column.Name == "InvLinePrice")
            {
                var val = CustInvLines.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (val !=null)
                {
                    var twoDecimal = Math.Truncate(100 * decimal.Parse(val.ToString())) / 100;
                    CustInvLines.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = twoDecimal.ToString("C2");
                }  
            }
    }
