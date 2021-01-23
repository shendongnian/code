        SearchResult ret = searcher.FindOneReturningDirectorySearchResult();
        if (ret == null)
            throw new ObjectNotFoundException("group", searcher.GetFilter());
        using (DirectoryEntry parent = ret.GetDirectoryEntry())
        {
            parent.RefreshCache();
            using (DirectoryEntry newUser = parent.Children.Add("CN=" + this.CommonName, CommonPropertyNames.ObjectClassNames.UserObjectClassName))
            {
                Utility.SetProperty(newUser, UserPropertyNames.Name, this.CommonName);
                Utility.SetProperty(newUser, "userPassword", "Cambia$123");
                Utility.SetProperty(newUser, "sAMAccountName", "testAD001");
                FillUserProperties(newUser);
                newUser.CommitChanges();
