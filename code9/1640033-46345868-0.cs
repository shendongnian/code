    if (userAccount.Properties["manager"].Value != null)
    {
      DirectorySearcher search2 = new DirectorySearcher(domain.GetDirectoryEntry())
      {
        Filter = string.Format("(distinguishedName={0})", userAccount.Properties["manager"].Value)
      };
      search2.PropertiesToLoad.Add("displayName");
      search2.PropertiesToLoad.Add("mail");
      search2.PropertiesToLoad.Add("manager");
      DirectoryEntry mgrAcc = search2.FindOne()?.GetDirectoryEntry();
    }
