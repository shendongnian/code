    if (e.CommandName == "Save")
    {
        GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        GridView gv = (GridView)row.FindControl("gvOrders");
        string Journal = (row.FindControl("txtJournalName") as TextBox).Text;
        //... some other code
    }    
