    protected void EditCustomer(object sender, GridViewEditEventArgs e)
    {
        gvCustomers.EditIndex = e.NewEditIndex;
        BindData();
    }
     
    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCustomers.EditIndex = -1;
        BindData();
    }
----------
----------
