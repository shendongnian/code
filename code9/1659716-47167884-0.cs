    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the row back to a datarowview
            DataRowView row = e.Row.DataItem as DataRowView;
            decimal NoOfOnes = 0;
            decimal NoOfColumns = e.Row.Cells.Count - 1;
            //loop all the columns and find the 1's
            for (int i = 0; i < NoOfColumns; i++)
            {
                if (row[i].ToString() == "1")
                {
                    NoOfOnes++;
                }
            }
            //find the label in the current row
            Label lbl = e.Row.FindControl("myLabel") as Label;
            //display results
            lbl.Text = string.Format("{0:N2}", (NoOfOnes / NoOfColumns) * 100);
        }
    }
