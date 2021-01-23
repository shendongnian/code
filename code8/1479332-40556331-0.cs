    protected void ApplyToAllButton_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in AttendanceRepeater.Items)
        {
            DropDownList ddl = (DropDownList)item.FindControl("AttendStatusDropDownList");
            if (ddl != null)
            {
                ddl.SelectedValue = AttendStatusAllDropDownList.SelectedValue;
            }
        }    
    }
