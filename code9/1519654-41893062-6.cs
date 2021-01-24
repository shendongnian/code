    public static dynamic[] Users => WMI.Query("SELECT * FROM Win32_UserAccount WHERE Disabled = 0").Select<dynamic, dynamic>(d => {
        using (var machineContext = new PrincipalContext(ContextType.Machine))
        using (Principal principal = Principal.FindByIdentity(machineContext, d.SID))
        d.IsAdmin = principal.GetGroups().Any(i => i.Sid.IsWellKnown(System.Security.Principal.WellKnownSidType.BuiltinAdministratorsSid));
        return d;
    }).ToArray();
