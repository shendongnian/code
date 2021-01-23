    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (GridView1.Rows.Count == 100)
            {
                Button button = e.Row.FindControl("btnUpdatePCTD") as Button;
                button.Enabled = true;
            }
            Label label = e.Row.FindControl("grandTotalPCT") as Label;
            label.Text = string.Format("{0:N2}", GridView1.Rows.Count);
        }
    }
