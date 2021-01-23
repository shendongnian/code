    // set up domain context for the currently connected AD domain
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        // find the group in question
        GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "YourGroupNameHere");
  
        // if found....
        if (group != null)
        {
           // iterate over members
           foreach (Principal p in group.GetMembers())
           {
               Console.WriteLine("{0}: {1}", p.StructuralObjectClass, p.DisplayName);
               // do whatever you need to do to those members
           }
        }
    }
