    protected void btnAdminReport_Click(object sender, EventArgs e)
    {
        string URL = string.Format("AdminReportView.aspx?DateFrom={0}&DateTo={1}&DrpUsrName={2}", 
            txtDate1.Text, 
            txtDate2.Text, 
            DropDownList1.SelectedValue);    
        Response.Redirect(URL);
    }
