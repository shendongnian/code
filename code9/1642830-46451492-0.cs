     protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Edit)
        {
  
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            sum += Convert.ToInt32(((Label)e.Row.Cells[4].FindControl("Label4")).Text);
            results.Text = sum.ToString();
        }
    }
