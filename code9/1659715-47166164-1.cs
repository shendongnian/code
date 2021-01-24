    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int countTrues = 0;
            //i = 1 because your first column is dispensable to this.
            for (int i = 1; i < e.Row.Cells.Count; i++)
            {
                if (Convert.ToBoolean(e.Row.Cells[i].Text))
                {
                    //If you get 1 from the database, it will convert to true, so it will increment the counter.
                    countTrues++;
                }
            }
    
            //The amount of "trues" multiplied by 100 divided by 6 which is the number of columns you have.
            ((Label)e.Row.FindControl("mylabel")).Text = ((countTrues * 100) / 6).ToString();
       }
    }
