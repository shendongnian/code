            protected void AddRows(object sender, EventArgs e)
    {
        GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
        string orderId = (row.FindControl("txtOrderId") as TextBox).Text.Trim().Replace(",", "");
        string orderDate = (row.FindControl("txtOrderDate") as TextBox).Text.Trim().Replace(",", "");
        //Write code here for textbox
        Response.Redirect(Request.Url.AbsoluteUri);
    }
