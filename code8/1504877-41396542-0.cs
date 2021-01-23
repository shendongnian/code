    public void getAllUserPrinicpals(ref List<UserPrincipal> principals, GroupPrincipal principal)
            {
                foreach (Principal princ in principal.GetMembers(true))
                {
                    if(princ is UserPrincipal)
                        principals.Add((UserPrincipal)princ);
                    else if (princ is GroupPrincipal)
                        getAllUserPrinicpals(ref principals, (GroupPrincipal)princ);
                }
            }
