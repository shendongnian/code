    protected void Page_LoadComplete(object sender, System.EventArgs e)
     {
        
       if (this.IsPostBack)
       {
         ApplyGridFilter(ddlItemGroup.SelectedValue);
       }
       else
       {
         ApplyGridFilter(string.Empty);
    
       }
     }
