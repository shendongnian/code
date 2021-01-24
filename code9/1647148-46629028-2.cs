    private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = lst_CustomerNo.DataSource as DataTable;
        if(cmbSort.SelectedItem == "A-Z")
            dt.DefaultView.Sort = "OrderName ASC";
        else
            dt.DefaultView.Sort = "OrderName DESC";
    }
