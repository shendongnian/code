            protected void Application_Start()
            {
                MvcHandler.DisableMvcResponseHeader = true;
            }
    
    and
    
            protected void Application_PreSendRequestHeaders()
            {
                Response.Headers.Remove("Server");
                Response.Headers.Remove("X-AspNet-Version");
            }
    
    
    
