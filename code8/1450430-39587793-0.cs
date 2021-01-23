    protected void btnupdate_Click(object sender, EventArgs e)
    {
        var flag = CheckValidation();
        if(!flag)
            return;
        //Some other Code
    }
    
    public bool CheckValidation()
    {
        var flag = false; // by default flag is false
        if (txtphysi.Text.Trim() == "")
        {
           lblerrmsg.Visible = true;
           lblerrmsg.Text = "Please Enter Physician Name";
           return flag;
        }
        //Some other Code
        flag = true; // change the flag to true to continue execution
        return flag;
    }
