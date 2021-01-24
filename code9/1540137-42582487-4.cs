    public static void DisposeSession()
    {
        try    
        {    
            FlushSession(true); // Method that does a commit if there is a transaction
        }
        finally
        {
            ISession Session = CurrentSessionContext.Unbind(sessionFactory);
    
            if (Session != null)
            {
                // Dispose closes the session too. And Close dispose the transaction
                // if there was one. And transaction Dispose rollbacks if it was pending.
                Session.Dispose();
            }
        }
    }
