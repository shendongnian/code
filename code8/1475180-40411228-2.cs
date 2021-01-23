    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            int spanColumn_1_start = 1;
            int spanColumn_1_length = 3;
            //apply colspan
            e.Row.Cells[spanColumn_1_start].ColumnSpan = 3;
            //remove the spanned cells
            for (int i = 1; i < spanColumn_1_length; i++)
            {
                e.Row.Cells.RemoveAt(spanColumn_1_start + 1);
            }
            //note that the startindex of the 2nd colspan is set after removing cells for 1st colspan
            int spanColumn_2_start = 2;
            int spanColumn_2_length = 3;
            //apply colspan
            e.Row.Cells[spanColumn_2_start].ColumnSpan = 3;
            //remove the spanned cells
            for (int i = 1; i < spanColumn_2_length; i++)
            {
                e.Row.Cells.RemoveAt(spanColumn_2_start + 1);
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = e.Row.DataItemIndex;
            //to make a rowspan you have to work backwards since the next row does not exist yet
            if (rowIndex == 1)
            {
                GridView1.Rows[rowIndex - 1].Cells[0].RowSpan = 2;
                e.Row.Cells.RemoveAt(0);
            }
            //span 4 rows in column 3 starting at row 6
            if (rowIndex == 9)
            {
                    int rowSpan = 4;
                    int columnIndex = 3;
                    //apply rowspan
                    GridView1.Rows[rowIndex - rowSpan].Cells[columnIndex].RowSpan = rowSpan;
                    //remove the spanned rows
                    for (int i = 1; i < rowSpan; i++)
                    {
                        GridView1.Rows[rowIndex - (rowSpan - i)].Cells.RemoveAt(columnIndex);
                    }
            }
        }
    }
