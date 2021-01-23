    public void getStores()
    {
        objCommand.CommandType = CommandType.StoredProcedure;
        objCommand.CommandText = "dbo.Store_Select";
    
        DataSet ds;
        ds = conn.GetDataSetUsingCmdObj(objCommand);
        ddlStore.DataSource = ds.Tables[0];
    
        if (ds.Tables[0].Rows.Count == 0)
        {
        /*No Store to display*/
        }
        else
        {
            foreach (DataRow current_row in ds.Tables[0].Rows)
            {
                ddlStore.DataTextField = "Store_Name";
                ddlStore.DataValueField = "Store_ID";
            }
        }
        ddlStore.DataBind();
        ddlStore.Items.Insert(0, new ListItem("Select a store", ""));
     }
