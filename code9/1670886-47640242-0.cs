       - and in the selecting event we can set the parameter value dynamically to previous row's drop down selected value.
            private int dropdpownValue;
    
            protected void ddlInsentiveCategory_SelectedIndexChanged ( object sender, EventArgs e) 
            {
             //get selected value of drop down and then find
             //the row index of this drop down control
             DropDownList ddl = sender as DropDownList;
             int.TryParse( (sender as DropDownList).SelectedItem.Value, out ddlValue);
             GridViewRow row = (GridViewRow) ddl.NamingContainer;
             int ddlRowIndex = row.RowIndex;
             //find the next row dropdownlist and if there is a next row,
             //then get this control and databind it
             GridView gridView =   (GridView)ddl.NamingContainer.NamingContainer ;
             if((ddlRowIndex + 1) <= (gridView.Rows.Count -1)) {
                 DropDownList nextRowDDL = ((System.Web.UI.WebControls.GridView)ddl.NamingContainer.NamingContainer ).Rows[ ddlRowIndex + 1].FindControl("ddlInsentiveCategory")
                 nextRowDDL.DataBind();
               }
            }
    
            protected void InsentiveDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
            {
               if(dropdpownValue> 0) {
                      e.Command.Parameters[0].Value=  dropdpownValue;
                      dropdownValue = 0;
               }
            }
