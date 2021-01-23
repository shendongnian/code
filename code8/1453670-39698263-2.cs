    protected void menu_list_SelectedIndexChanged(object sender, EventArgs e)
    {
        string value = menu_list.SelectedValue;
        if (value.Equals("profile"))
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "LoadProfile();", true);
        }
        else if (value.Equals("booking"))
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "LoadBooking();", true);
        }
        else if (value.Equals("status"))
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "LoadStatus();", true);
        }
        else if (value.Equals("approval"))
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "LoadApproval();", true);
        }
        else if (value.Equals("cancel"))
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "LoadCancel();", true);
        }
    }
