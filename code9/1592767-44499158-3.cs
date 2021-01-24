    if (e.Row.RowType == DataControlRowType.DataRow)
      {
         if (lbltype.Text != "admin")
           {
             LinkButton deleteLink = (LinkButton)e.Row.Cells[e.Row.Cells.Count - 1].Controls[2];
             if(deleteLink != null && deleteLink.Text.Equals("Delete"))
               {
                  deleteLink.Visible = false;
               }
           }
      }
