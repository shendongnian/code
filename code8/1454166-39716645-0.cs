    <!-- language: c# -->
        using System.Security.Principal;
        // above the "try" block
		WindowsImpersonationContext _ImpersonationIdentity = null;
        // inside the "try", before anything else
        _ImpersonationIdentity = SqlContext.WindowsIdentity.Impersonate();
        // in a "finally" block
        if (_ImpersonationIdentity != null)
        {
          _ImpersonationIdentity.Undo();
        }
