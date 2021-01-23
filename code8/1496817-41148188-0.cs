       var GetAllPersonalCalls = from c in db.MyAllPhoneBillContext
                                      join p in db.MyPersonalNumContext on c.CALLED_NUMBER equals p.PersonalNumber
                                      where c.CALLING_NUMBER == My_Number
                                      where c.CALL_DATE.Year == currentYear
                                      where c.CALL_DATE.Month == currentMonth
                                      select new PhoneBillVM
                                      {
                                          CALLING_NUMBER = c.CALLING_NUMBER,
                                          CALLED_NUMBER = c.CALLED_NUMBER,
                                          CALL_DURATION = c.CALL_DURATION,
                                          CustomTime = c.CALL_TIME.Hour + ":" + c.CALL_TIME.Minute + ":" + c.CALL_TIME.Second,
                                          CALL_COST = c.CALL_COST,
                                          CALL_DATE = c.CALL_DATE
                                      };
