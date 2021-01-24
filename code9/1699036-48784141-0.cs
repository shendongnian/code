    string userName = null;
    using (System.Security.Principal.WindowsIdentity identity = 
            System.Security.Principal.WindowsIdentity.GetCurrent())
    {
       userName = identity.Name;
    }
