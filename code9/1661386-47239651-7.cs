    if (e.CommandName.Equals("Pay")) {
      //you don't need NamingContainer to get Row in RowCommand event
     //since its already available under the GridViewCommandEventArgs object
      GridViewRow row = e.Row;
       
      if (row != null) {
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
