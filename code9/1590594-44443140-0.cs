    d.SetDataSource(cn.Customers.Select(c => new
            {
                CustomerID = c.CustomerID  ? DBNull.Value : c.CustomerID  ,
                CustomerName = c.CustomerName  ? DBNull.Value : c.CustomerName  ,
                CustomerEmail = c.CustomerEmail  ? DBNull.Value : c.CustomerEmail  ,
                CustomerZipCode = c.CustomerZipCode  ? DBNull.Value : c.CustomerZipCode  ,
                CustomerCountry = c.CustomerCountry  ? DBNull.Value : c.CustomerCountry ,
                CustomerCity = c.CustomerCity == null ? DBNull.Value : c.CustomerCity,
            }).ToList());
