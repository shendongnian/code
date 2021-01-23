    public void Update(int acctId)
    {
        using(var context = new Context())
        {
            using(var dbContextTransaction = new context.Database.BeginTransaction())
            {
                try
                {
                    //improved query
                    var acct = context.Regression_TestAccounts
                                      .FirstOrDefault(f => f.Account_ID == acctId);   
                    if(acct == null) //don't just return, tell the user there was no update
                        return;  
    
                    acct.AvailableDailyCreditLimit_Amt = acct.ApprovedDailyCreditLimit_Amt;
                    acct.AvailableTotalCreditLimit_Amt = acct.ApprovedTotalCreditLimit_Amt;
                                                                                                 
                    context.Entry(acct).State = acct.Account_ID == 0 
                                              ? EntityState.Added 
                                              : EntityState.Modified;
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }
    }
