    public string TranscationDetails(string Account_Number)
    {
         using (HalifaxDatabaseEntities context = new HalifaxDatabaseEntities())
         {
             var CombinedQuery = (from x in context.Current_Account_Deposit
                                 join y in context.Current_Account_Withdraw
                                 on x.Account_Number equals y.Account_Number
                                 where x.Account_Number == Convert.ToInt32(Account_Number)
                                 select new { 
                                    x.Account_Number,
                                    // put other properties here 
                                 }).ToList();
    
             var js = new System.Web.Script.Serialization.JavaScriptSerializer();
    
             return js.Serialize(CombinedQuery); // return JSON string
         }
    }
