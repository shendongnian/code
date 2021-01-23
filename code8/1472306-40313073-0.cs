    // set up domain context - limit to the OU you're interested in
    // use this constructor if you want just the default domain, and search in the whole domain
    //     using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, null))
    // or use this line here to define a *container* to search inside of 
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, null, "OU=YourOU,DC=YourCompany,DC=Com"))
    {
        // find the group in question - this can be either a DL, or a security group - both should be found just fine
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
