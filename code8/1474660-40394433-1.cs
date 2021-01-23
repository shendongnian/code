    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
               
          if (e.Row.Cells[0].Text == "10537")
          {
             Button btnHidden = e.Row.FindControl("btnHidden") as Button;
             if (btnHidden != null)
             {
                 btnHidden.CssClass = "btnHidden";
             }
         }
    }
