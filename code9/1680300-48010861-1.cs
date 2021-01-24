    //Optionally do a hide(); here.
    AddCustomer customer = new AddCustomer();
    DialogResult result = customer.ShowDialog();
    if(result == DialogResult.OK)
    {
        var name = customer.Name;
        //More properties or whatever here.
    }
    //The properties would still be accessible here, too.
