    public void GetUserName()
    {
        // other stuff
    
        DataTable dt = conn_.SelectData(cmd);
        Session["Datatable"] = dt;
    
        // other stuff
    }
    
    // Button click event handler
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var value = usernameInput.Value;
        DataTable dt = (DataTable)Session["Datatable"];
        string expression = "USER_NAME = '" + value + "'";
    
        DataRow[] result = dt.Select(expression);
        
        input_selected.Value = result[0][0].ToString(); // ensure the result is only a single user ID result
    }
