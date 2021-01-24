        public void A(ISession objSession)
        {
            //functions
        }
        public void B(ISession objSession)
        {
            //functions
        }
        public void mainFunction()
        {  
            ISession objSession = base.GetCurrentSession;
            using (ITransaction transaction = objSession.BeginTransaction)
            {
             try 
             {
               A(objSession);
               B(objSession);
               //If successful for everything:
               objSession.Flush();
               objSession.Commit();
             }
             catch (Exception ex)
             {
               transaction.Rollback();
             }
        }
