    Customer aCustomer = new Customer(); //Customer object created
    /**Assign values - Starts**/
    aCustomer.CustomerId = 1001;
    aCustomer.CustomerName = "John";
    aCustomer.Address = "On Earth";
    aCustomer.Status = "Active";
    custDictionary.Add(aCustomer.Status, aCustomer); //Add first customer 
    aCustomer.CustomerId = 1002;
    aCustomer.CustomerName = "James";
    aCustomer.Address = "On Earth";
    aCustomer.Status = "Inactive";
    /**Assign values - Ends**/
    custDictionary.Add(aCustomer.Status, aCustomer); //Add second customer
