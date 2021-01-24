    /// <summary>
    /// Microsoft Office add-ins can experience
    /// <code>System.Runtime.Serialization.SerializationException</code> 
    /// "Type is not resolved for member Csla.Security.UnauthenticatedPrincipal".
    /// Calling this method before showing any UI works around the problem.
    /// </summary>
    public static void ExceptionWorkaround(bool setUnauthenticatedPrincipal = false)
    {
        // 1. Force initialisation of ConfigurationManager
        ConfigurationManager.GetSection("Dummy");
        // 2. Set User explicitly
        if (setUnauthenticatedPrincipal)
            Csla.ApplicationContext.User = new UnauthenticatedPrincipal();
        else
            Csla.ApplicationContext.User = Csla.ApplicationContext.User;
    }
