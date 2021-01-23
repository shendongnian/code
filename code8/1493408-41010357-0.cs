    public static List<IdentityResource> GetIdentityResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResources.OpenId()
            new IdentityResources.Profile() // <-- usefull
        }
    }
