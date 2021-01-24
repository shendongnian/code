    protected void Page_LoadComplete(object sender, System.EventArgs e)
     {
        
       if (this.IsPostBack)
       {
         ApplyGridFilter(ddlItemGroup.SelectedValue);// it will hit on first time page load 
       }
       else
       {
         ApplyGridFilter(string.Empty);// it will hit while you change the dropdown items, But you should set true for **IsAutoPostBack** property on dropsownlist.    
       }
     }
