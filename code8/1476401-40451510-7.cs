        public static AccountsCTX GetEveryBalance(long currentCustomerSsn)
        { 
         AccountsCTX everyBalance = db.Accounts.Join(db.Customer, a => a.SSN, 
                                                                              c => c.SSN, 
                                                                      (a, c) => new AccountsCTX()
                {
                    //id = a.id,
                    SSN = a.SSN,
                    accountname = a.accountname,
                    accountnumber = a.accountnumber,
                    balance = a.balance
                }
                                    ).Where(x=>x.SSN==currentCustomerSsn).FirstOrDefault();//currentCustomerSsn is enter ssn by Customer
                return everyBalance;
        }
    
        //Create customer
        public long insertCusReg(CustomerCTX inCusReg)
        {
            ...
            try
            {
                ...
                return inCusReg.SSN;
            }
            catch (Exception)
            {
                return 0;
            }
            
        } 
