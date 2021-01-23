    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the rowtype is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //loop all the cells in the row
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                int value = 0;
    
                //try converting the cell value to an int
                try
                {
                    value = Convert.ToInt32(e.Row.Cells[i].Text);
                }
                catch
                {
                }
    
                //check the value and set the background color
                if (value == 0)
                {
                    e.Row.Cells[i].BackColor = Color.Red;
                }
                else
                {
                    e.Row.Cells[i].BackColor = Color.Green;
                }
            }
        }
    }
