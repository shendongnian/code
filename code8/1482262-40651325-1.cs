    PrincipalContext pricipalContext = new PrincipalContext(ContextType.Domain);
            GroupPrincipal group = GroupPrincipal.FindByIdentity(pricipalContext, department);
            if (group != null)
            {
                foreach (Principal principal in group.Members)
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(pricipalContext, principal.Name);
                    employees.Add(new AdEmployees() { name = user.Name });
                }
            }
