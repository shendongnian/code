    List<AccountsCTX> everyBalance = db.Accounts.Join(db.Customer,
                                                       a => a.id, 
                                                       c => c.id, 
                                                       (a, c) => new { db.Accounts= a, db.Customer= c })
                                                       .Select(x=>new AccountsCTX 
                                                         {
                                                           //id = a.id,
                                                           SSN = a.SSN,
                                                           accountname = a.accountname,
                                                           accountnumber = a.accountnumber,
                                                           balance = a.balance
                                                           //Customer=c.Name
                                                         }).ToList();
                                       
                    return everyBalance;
