        IQueryable<Customer> query = dc.Customer
                                       .Where(cust =>
                                       cust.Contact.Select(con => 
                                       con.FirstName.ToUpperInvariant() 
                                       + " " +          
                                       con.LastName.ToUpperInvariant())
                                      .Contains(searchText.ToUpperInvariant()));
