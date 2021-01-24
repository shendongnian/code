    var customer = Context.tblCustomers.FirstOrDefault(c => c.CustomerID == CustomerID);
    if (customer != null)
    {
        _tblCustomer.CustomerCode = customer.CustomerCode; 
        _tblCustomer.CustomerName = customer.CustomerName;
        _tblCustomer.CustomerLastName = customer.CustomerLastName;
        _tblCustomer.CustomerID = customer.CustomerID;
        _tblCustomer.CustomerAdresse = customer.CustomerAdresse;
        _tblCustomer.CustomerCellPhone = customer.CustomerCellPhone;
        _tblCustomer.CustomerPhone = customer.CustomerPhone;
    }
