    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //get the control that fired the method
        Control control = e.CommandSource as Control;
    
        //get the row containing the control
        GridViewRow gvr = control.NamingContainer as GridViewRow;
    
        //get the row number
        int rowNumber = gvr.RowIndex;
    
        //declare the column variable
        int columnNumber = -1;
    
        //loop all the columns in the gridview
        for (int i = 0; i < GridView1.Columns.Count; i++)
        {
            //try to find the button that was clicked in each individual cell
            Button button = GridView1.Rows[rowNumber].Cells[i].FindControl(control.ID) as Button;
    
            //if the button is found set the column number
            if (button != null)
            {
                columnNumber = i;
            }
        }
        //get the column name
        Label1.Text = GridView1.HeaderRow.Cells[columnNumber].Text;
    }
