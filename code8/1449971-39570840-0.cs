     protected void LoadFilteredDropdown(string term)
     {
    // send term to Services.StaticLists.Master.CLI.Active_Filtered_List here
    ddlClientFiltered.Items.Clear();
    ddlClientFiltered.Items.Add(new ListItem("- Select", "0"));
    ddlClientFiltered.AppendDataBoundItems = true;
    ddlClientFiltered.DataSource = Services.StaticLists.Master.CLI.Active_Filtered_List(term);
    ddlClientFiltered.DataBind();
    ddlClientFiltered.SelectedIndex = 0;
    }
      private static List<DefaultDesc_List> cli_Active_Filtered_List = null;
     public static List<DefaultDesc_List> Active_Filtered_List(string term)
     {
    get
    {
        var db = new Entities();
        string term = ""; // receive the term here
        var results = (from cli in db.CDC_M_Client_CLI
                       where cli.CLI_Active == true &&
                       cli.CLI_Name.StartsWith(term)
                       orderby cli.CLI_Name
                       select new
                       {
                           cli.CLI_Id,
                           cli.CLI_Name,
                           cli.CLI_Active
                       }).ToList();
        cli_Active_Filtered_List = new List<DefaultDesc_List>();
        foreach (var result in results)
        {
            if(result.CLI_Active)
            {
                cli_Active_Filtered_List.Add(new DefaultDesc_List()
                {
                    Id = result.CLI_Id,
                    Desc = result.CLI_Name
                });
            }
        }
        return cli_Active_Filtered_List;
    }
     }
