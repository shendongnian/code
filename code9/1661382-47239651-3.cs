    if (e.CommandName.Equals("Pay")) {
     using(con) {
      GridViewRow row = (sender as Control).NamingContainer as GridViewRow;
      //cannot use RowIndex
      if row != null) {
      string fname = null;
    
      //check if row is in edit mode by checking if textbox exists
      if (row.FindControl("txtForename") != null) {
       fname = ((TextBox) row.FindControl("txtForename")).Text.Trim();
      } else {
       fname = ((Label) row.FindControl("lblForename")).Text.Trim();
      }
    
       Response.Redirect("~/Bill.aspx?lblF=" + fname);
      }
     }
    }
