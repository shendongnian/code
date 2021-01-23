          public List<Customer> getLogsByCustomerName(string customername)
          {
              using (var dbentites = new CustomerEntities())
              {
                var result = (from res in dbentites.Customer.OrderByDescending(_ => _.CustomerName)
                              where res.CustomerName == customername
                              select res).ToList();
                 return result.ToList();
            }
         }
