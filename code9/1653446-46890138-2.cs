    try
    {
       using (var pcLocal = new PrincipalContext(ContextType.Machine))
       {
          var group = GroupPrincipal.FindByIdentity(pcLocal, "Administrators");
    
          using (var pcDomain = new PrincipalContext(ContextType.Domain, "AAA"))
          {
             group.Members.Add(pcDomain, IdentityType.SamAccountName, "User123");                            group.Save();
          };
       };
    } catch (Exception e)
    {
       Console.WriteLine(e.Message);
    };
