    /// <summary>
    /// Handles the HttpApplication's Error event.
    /// </summary>
    protected void Application_Error() 
    {
         // Put a breakpoint here to give you an idea of what is going wrong.
         Exception exception = this.Server.GetLastError();
    }
