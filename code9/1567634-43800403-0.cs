    public static void InsertGroupAccountManagement(UserPrincipal userPrincipal)
    {
        using (GroupPrincipal adGroup = GroupPrincipal.FindByIdentity(_principalGroupContext, IdentityType.Guid, WKIS_USER_GROUP_ID))
        {
            adGroup.Members.Add(userPrincipal);
            adGroup.Save();
            adGroup.Members.Remove(userPrincipal);
            adGroup.Save();
        }
    }
