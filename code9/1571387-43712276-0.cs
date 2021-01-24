     void CustomersGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
      {
    
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
    
          //GET THE BUTTON.
          Button button1 = (Button)e.Row.FindControl("btn_agregar");
    
          //CHECK CONDITION AND SHOW/HIDE ACCORDINGLY.
          if (YOUR CONDITION)
             button1.Visible = true; 
          else
             button1..Visible = false; 
    
        }
     }
