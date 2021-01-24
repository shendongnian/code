    private void CustomersPhone_ComBx_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CustomersPhone_ComBx.Text != "")
             CustomersName_ComBx.DataSource = Customers
                              .Where(Customer => Customer.Phone == CustomersPhone_ComBx.Text)
                              .Select(Customer => Customer.Name).ToList();
        else
             CustomersName_ComBx.DataSource = Customers.Select(Customer => Customer.Name).ToList();
    }
