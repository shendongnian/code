    decimal price = 0;
    int piece = 0;
    decimal totalPrice = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            // This will mulitply the price and piece and add it to final total.
            totalPrice += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "price")) * Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "piece"));
        }
        else if(e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total Price:";
            e.Row.Cells[2].Text = totalPrice.ToString("c");
            e.Row.Cells[1].HorizontalAlign = e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Font.Bold = true;
        }
    }
