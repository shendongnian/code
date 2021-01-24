    public void CheckGroupMembership()
        {
            // set up domain context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "XXX");
            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, GetUserName());
            for (int i = 0; i < 3; i++)
            {
                // find the group in question
                GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, groupName[i]);
                if (user != null)
                {
                    // check if user is member of that group
                    if (user.IsMemberOf(group))
                    { 
                        IsMember[i] = true;  
                    }
                    else
                    {
                        IsMember[i] = false;
                    }
                }
            }
        }
