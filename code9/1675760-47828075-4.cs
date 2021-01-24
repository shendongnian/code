    string previousCellValue = "";
    int previousCellCount = 1;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow and not the first row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the dataitem back to a row
            DataRowView row = e.Row.DataItem as DataRowView;
            //check if the current id matches the previous row
            if (previousCellValue == row["Id"].ToString())
            {
                //count the number of same cells
                previousCellCount++;
            }
            else
            {
                //span the rows for the first two cells
                if (previousCellCount > 1)
                {
                    GridView1.Rows[e.Row.RowIndex - previousCellCount].Cells[0].RowSpan = previousCellCount;
                    GridView1.Rows[e.Row.RowIndex - previousCellCount].Cells[1].RowSpan = previousCellCount;
                    //hide the other cells in the column
                    for (int i = 1; i < previousCellCount; i++)
                    {
                        GridView1.Rows[(e.Row.RowIndex - previousCellCount) + i].Cells[0].Visible = false;
                        GridView1.Rows[(e.Row.RowIndex - previousCellCount) + i].Cells[1].Visible = false;
                    }
                }
                previousCellValue = row["Id"].ToString();
                previousCellCount = 1;
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            //use the footer row to create spanning for the last rows if needed
            if (previousCellCount > 1)
            {
                GridView1.Rows[GridView1.Rows.Count - previousCellCount].Cells[0].RowSpan = previousCellCount;
                GridView1.Rows[GridView1.Rows.Count - previousCellCount].Cells[1].RowSpan = previousCellCount;
                //hide the other cells in the column
                for (int i = 1; i < previousCellCount; i++)
                {
                    GridView1.Rows[(GridView1.Rows.Count - previousCellCount) + i].Cells[0].Visible = false;
                    GridView1.Rows[(GridView1.Rows.Count - previousCellCount) + i].Cells[1].Visible = false;
                }
            }
        }
    }
