     protected void Databound(object sender, GridViewRowEventArgs e)
     {
          if (e.Row.RowType == DataControlRowType.DataRow && 
                 YOUR GRIDVIEWID.EditIndex == e.Row.RowIndex)
          {
              YOUR GRIDVIEWID.EditRowStyle.BackColor = System.Drawing.Color.YOURCOLOUR;
          }
     }
