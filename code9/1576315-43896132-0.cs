        public Account GetAccountById(int AccountId, bool includePayments = false, bool includeOwners)
      {
            var query = context.Account;
    
          if(includePayments)
          {
             query = query.Include(c => c.Payments).AsQueryable()
          }
    
          if(includeOwners)
          {
             query = query.Include(c => c.Owners).AsQueryable()
          }
                          
          return  query.Single(a => a.AccountId == AccountId)
    }
