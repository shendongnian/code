    protected void YourFormView_DataBound(Object sender, EventArgs e)
    {
        Label uname = (Label)AddItemFv.Row.FindControl("SubmitByLbl");
            if (uname != null)
                uname.Text = Session["RegUser"].ToString();
    
            TextBox udate = (TextBox)AddItemFv.Row.FindControl("SubmitDTTextBox");
            if (udate != null)
                udate.Text = DateTime.Now.ToString();
    }
