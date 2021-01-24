    DataTable dt = new DAL_Reports().Rpt_Count_Transpose(from_date, to_date);
    
    //create a array to store the total column values
    int[] RowTotals = new int[dt.Columns.Count];
    
    //loop all the rows in the datatable
    foreach (DataRow row in dt.Rows)
    {
        //loop all the columns in the row
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            //add the values for each cell to the total
            RowTotals[i] += Convert.ToInt32(row[dt.Columns[i].ColumnName]);
        }
    }
    
    //loop all the columns again to set the values in the footer
    for (int i = 0; i < dt.Columns.Count; i++)
    {
        GridView1.FooterRow.Cells[i].Text = string.Format("{0:N2}", RowTotals[i]);
    }
