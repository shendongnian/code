    int total = 0;
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    if(e.Row.RowType==DataControlRowType.DataRow)
    {
    total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Total Employee"));
    }
    if(e.Row.RowType==DataControlRowType.Footer)
    {
    Label lblTotal= (Label)e.Row.FindControl("lblTotalEmployee");
    lblTotal.Text = total.ToString();
    }
    }
