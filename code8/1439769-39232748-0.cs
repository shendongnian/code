    public void Update(int acctId)
    {
        using(var context = new Context())
        {
            using(var dbContextTransaction = new context.Database.BeginTransaction())
            {
                try
                {
                    var acct = context.Regression_TestAccounts
                                      .FirstOrDefault(f => f.Account_ID.Equals(acctId));   
                    if(acct == null) 
                        return;  
    
                    acct.AvailableDailyCreditLimit_Amt = acct.ApprovedDailyCreditLimit_Amt;
                    acct.AvailableTotalCreditLimit_Amt = acct.ApprovedTotalCreditLimit_Amt;
                                                                                                 
                    context.Regression_TestAccounts.Add(acct);
                    context.Entry(acct).State = acct.Id == 0 
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
