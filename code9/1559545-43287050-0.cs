    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the current row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ///create a new linkbutton
            LinkButton button = new LinkButton();
            button.Text = "LinkButton";
            button.CommandArgument = "MyArgs";
            //assign a command to the button
            button.Command += Button_Command;
            //add the button to cell x
            e.Row.Cells[3].Controls.Add(button);
        }
    }
