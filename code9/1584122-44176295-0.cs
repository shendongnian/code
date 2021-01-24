    using (var principalContext = new PrincipalContext(ContextType.Domain, "TEST.COM", "DC=TEST,DC=COM"))
                    {
                        //using (var group = GroupPrincipal.FindByIdentity(context, windowsGroup.TrimEnd('*')))
                        using (var groupPrincipal = GroupPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, "groupName"))
                        {
                            if (groupPrincipal != null)
                            {
                                var users = groupPrincipal.GetMembers();
                                foreach (UserPrincipal userPrincipal in users)
                                {
                                    //user variable has the details about the user 
                                }
                            }
                        }
                    }
