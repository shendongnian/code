    public bool IsSubscriptionExist(string domain)
        {
            try
            {
                using (AccContext db = new AccContext ())
                {
                    var count = (from s in db.Subscriptions
                                 join a in db.Allias on s.Id equals 
                                 a.Subscription_Id into ps
        		                 from a in ps.DefaultIfEmpty()
                                 where (s.Domain == domain || a.Allias_Domain == domain)
                                 select s).Count();
        
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                customLogManager.Error(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                throw ex;
            }
        }
