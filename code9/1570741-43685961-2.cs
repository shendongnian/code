    public static Customer SelectCustomerByUser(string user)
    {
        var query = (from p in dc.Customers
                     where p.No_ == user
                     select p).Single();
        return query;
    }
    
    var queryresult = CustomerClass.SelectCustomerByUser(user) as Customer;
    if(queryresult!=null)
      lblStreet.Text= queryresult.Street;  
