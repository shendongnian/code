    using (var ctx = new PrincipalContext(ContextType.Domain,
                _webApiServiceConfiguration.Domain,
                _webApiServiceConfiguration.DomainAccessUserName,
                _webApiServiceConfiguration.DomainAccessPassword))
    {
        UserPrincipal userAd = UserPrincipal.FindByIdentity(ctx,user.USERID);
        // if not null, get the underlying DirectoryEntry
        if (userAd != null) 
        {
            DirectoryEntry de = userAd.GetUnderlyingObject() as DirectoryEntry;
            // if de is not null
            if (de != null) 
            {
                // get the property in question - possibly the "photo" property
                if(de.Properties["photo"] != null)
                {
                     // unlike a database column, an AD property can contain *multiple* values....
                     
                }
            }
    }
