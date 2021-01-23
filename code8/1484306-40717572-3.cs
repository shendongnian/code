    protected void gvBookings_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //find the dropdownlist in the current row with findcontrol and cast back to one
            DropDownList dropDownList = e.Row.FindControl("DropDownList1") as DropDownList;
    
            //add some listitems
            dropDownList.Items.Insert(0, new ListItem("Text A", "A"));
            dropDownList.Items.Insert(1, new ListItem("Text B", "B"));
            dropDownList.Items.Insert(2, new ListItem("Text C", "C"));
    
            //select a value in the dropdown
            dropDownList.SelectedValue = "B";
        }
    }
    
    protected void gvBookings_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check the commandname
        if (e.CommandName == "saveTextBox")
        {
            //convert the commandargument to a row number
            int rowNumber = Convert.ToInt32(e.CommandArgument);
    
            //find the textbox in the current row with findcontrol and cast back to one
            TextBox textBox = gvBookings.Rows[rowNumber].FindControl("TextBox1") as TextBox;
    
            //do stuff with the textbox value
            Label1.Text = textBox.Text;
        }
    }
