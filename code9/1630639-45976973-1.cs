    protected void btnBook_Click(object sender, EventArgs e)
    {
        // get clicked item of datalist
        DataListItem dli = (sender as Button).NamingContainer as DataListItem;
        // access clecked data from datalist
        string id = DataBinder.Eval(dli, "P_ID").ToString();
        string name = DataBinder.Eval(dli, "P_name").ToString();
        // ... other fields
        string sendingData = id + "," + name;
        // send data using query string
        Response.Redirect("PaymentGateway.aspx?data="+sendingData);
    }
