    protected void Session_Start(object src, EventArgs e)
            {
                if (Context.Session != null)
                {
                    if (Context.Session.IsNewSession)
                    {
                        Context.Session.Timeout = 50;
    
                    }
                }
            }
