    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MYCOMMAND")
        {
            //Existing code related to "MYCOMMAND"
        }
        //Handle "GenerateBill" command as following.
        else if(e.CommandName == "GenerateBill")
        {
            int enquiryId = Int32.Parse(e.CommandArgument.ToString());
            GenerateBill(enquiryId) //Calling generate bill method with enquiryid.
        }
    }
