        I got the same issue with EF. At beginning, the exception was thrown once a day, after 10 times/day
    and recently 48 times/day. Of course, we cannot reproduce this "The underlying provider failed on open". 
    I did everything, be sure we don't leak connections, always use                  
        
        using (var context = new DataContext())
                    {
                        List<Billing> result = (from item in context.Billing.AsNoTracking()
                                                      select item).ToList();
                          return result;
                    }
        
        For us, the solution was to force the opening of the connection.
         public DataContext()
                 : base("your connectionstring")
               
                    **this.Database.Connection.Open();**
                    this.Configuration.LazyLoadingEnabled = false;
            		this.Configuration.ProxyCreationEnabled = false;
                }
        
        Hope it works for you, too!
