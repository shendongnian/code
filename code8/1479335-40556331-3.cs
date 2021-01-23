    protected void ApplyToAllButton_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in AttendanceRepeater.Items)
        {
            DropDownList ddl = (DropDownList)item.FindControl("AttendStatusDropDownList");
            if (ddl != null && string.IsNullOrEmpty(ddl.SelectedValue))
            {
                ddl.SelectedValue = AttendStatusAllDropDownList.SelectedValue;
            }
        }    
    }
