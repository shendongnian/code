            public IList<CustomerDTO> FindCustomers(String ColumnName, String SearchText)
            {
    
                var query = from s in db.Customers select s;
    
                if (ColumnName == "CompanyName")
                {
                    query = query.Where(c => c.CompanyName == SearchText);
                }
                else if (ColumnName == "ContactName")
                {
                    query = query.Where(c => c.ContactName == SearchText);
                }
                //. . .
                else
                {
                    throw new InvalidOperationException($"Column {ColumnName} not found or not supported for searching.");
                }
    
                var results = from c in query
                            select new CustomerDTO()
                            {
                                CustomerID = c.CustomerID,
                                CompanyName = c.CompanyName,
                                ContactName = c.ContactName,
                                ContactTitle = c.ContactTitle,
                                Address = c.Address
                            };
    
                return results;
    
            }
