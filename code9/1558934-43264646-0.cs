    protected void NestedGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the current row is a datarow
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            //create 4 buttons in a loop
            for (int i = 0; i < 4; i++)
            {
                //create a new button
                Button button = new Button();
                button.Text = "Button " + (i + 1);
                //add a click handler to the button
                button.Click += Button1_Click;
                //add the button to the footer row
                e.Row.Cells[i].Controls.Add(button);
            }
        }
    }
