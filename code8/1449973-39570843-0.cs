    protected void LoadFilteredDropdown(string term)
    {
        // send term to Services.StaticLists.Master.CLI.Active_Filtered_List here
        ddlClientFiltered.Items.Clear();
        ddlClientFiltered.Items.Add(new ListItem("- Select", "0"));
        ddlClientFiltered.AppendDataBoundItems = true;
        ddlClientFiltered.DataSource 
          = Services.StaticLists.Master.CLI.Active_Filtered_List(term); // <-- here
        ddlClientFiltered.DataBind();
        ddlClientFiltered.SelectedIndex = 0;
    }
