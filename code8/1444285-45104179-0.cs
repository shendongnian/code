     if (rule.FileSystemRights == FileSystemRights.Read)
     {
      Console.WriteLine("Account:{0}", rule.IdentityReference.Value);
     }
    }
