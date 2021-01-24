    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
        if (e.Row.RowType == DataControlRowType.Pager && GridView1.PageCount==1 )
        {
            var a = e.Row.Controls;
            if (a.Count>0 && a[0] is TableCell)
            {
                var b = a[0].Controls[0].Controls[0] as TableRow;
                if (b != null)
                {
                    //This is actually your page 1 text
                    b.Cells[0].Text = "";
                }
             }
         }
    }
