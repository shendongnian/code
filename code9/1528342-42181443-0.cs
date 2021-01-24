      protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
       if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
   
     do something like...
    
      
    DropDownList gvComponentLocks = (DropDownList)e.Row.FindControl("DropDownList1");
     gvComponentLocks.DataSource=getComponentsAndLocks(worksPermitID);
     gvComponentLocks.Bind();
    
    Alternatively return from a ListItemCollection, preferably...
     
