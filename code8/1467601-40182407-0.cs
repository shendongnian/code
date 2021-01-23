    using (var ou = new DirectoryEntry(ouPath, ldapUser, ldapPassword))
    {
         using (var group = new DirectoryEntry(groupPath, ldapUser, ldapPassword))
         {
              ou.Children.Remove(group);
              group.CommitChanges();
         }
    }
