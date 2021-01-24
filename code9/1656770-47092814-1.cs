    Customer old;
    if (customers.TryGetValue(ID, out old))
    {
        var newCustomer = new Customer(newName,old.LastName,old.CustID);
        if(!customers.TryUpdate(ID,newCustomer,old))
        {
            // Who moved my cheese ?
        }
    }
    else
    {
        //No customer!
    }
