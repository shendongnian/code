    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the row back to a datarowview
            DataRowView row = e.Row.DataItem as DataRowView;
            //loop all columns in the row
            for (int i = 0; i < row.DataView.Count; i++)
            {
                string cellValue = row[i].ToString();
                //loop all rows in gridview1 
                for (int j = 0; j < GridView1.Rows.Count; j++)
                {
                    //loop all cells in gridview1
                    for (int k = 0; k < GridView1.Columns.Count; k++)
                    {
                        string cellValueCompare = GridView1.Rows[j].Cells[k].Text;
                        //compare values and color cell
                        if (cellValue == cellValueCompare)
                        {
                            GridView1.Rows[j].Cells[k].BackColor = Color.Green;
                        }
                    }
                }
            }
        }
    }
