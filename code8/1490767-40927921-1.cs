    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the rowtype is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string lastLetter = string.Empty;
    
            //check if cell 1 actually contains data, otherwise substring will fail
            if (!string.IsNullOrEmpty(e.Row.Cells[0].Text))
            {
                //get the last letter of the string in cell 1
                lastLetter = e.Row.Cells[0].Text.Substring(e.Row.Cells[0].Text.Length - 1, 1).ToUpper();
            }
    
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
                if (value == 1 && lastLetter == "H")
                {
                    e.Row.Cells[i].BackColor = Color.Green;
                }
                else if (value == 1 && lastLetter == "N")
                {
                    e.Row.Cells[i].BackColor = Color.Blue;
                }
                else
                {
                    e.Row.Cells[i].BackColor = Color.White;
                }
            }
        }
    }
