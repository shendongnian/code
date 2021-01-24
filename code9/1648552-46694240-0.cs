    foreach (RepeaterItem item in rptDatabases.Items)
    {
        CheckBox checkbox = item.FindControl("checkboxDatabase") as CheckBox;
    
        if (checkbox != null && checkbox.Checked)
        {
            selectedDatabases.Add(checkbox.Text);
        }
    }
