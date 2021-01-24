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
                // Dispose closes the session too.
                Session.Dispose();
            }
        }
    }
