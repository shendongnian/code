     protected void Databound(object sender, GridViewRowEventArgs e)
     {
     if (e.Row.RowType == DataControlRowType.DataRow && GVSocialMedia.EditIndex == e.Row.RowIndex)
       {
      YOUR GRIDVIEWID.EditRowStyle.BackColor = System.Drawing.Color.YOURCOLOUR;
       }
     }
