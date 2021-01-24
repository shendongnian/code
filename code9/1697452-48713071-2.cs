    IQueryable<Customer> query = dc.Customer
                                       .Where(cust =>
                                       cust.Contact.Select(con => 
                                       con.FirstName.ToUpperInvariant().Trim()
                                       +                                   
                                       con.LastName.ToUpperInvariant().Trim())                                      
                                         .Contains(searchText.ToUpperInvariant()
                                             .Replace(" ", string.Empty).Trim()));
