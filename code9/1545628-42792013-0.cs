       using (new Impersonator(user, domain, password
                       , LogonType.LOGON32_LOGON_NEW_CREDENTIALS, LogonProvider.LOGON32_PROVIDER_WINNT50
                    ))
      {
         Console.WriteLine("IMPERSONATE LOGON32_LOGON_NEW_CREDENTIALS with " + user);
             p1 = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
             Console.WriteLine(p1);
             p1 = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
             Console.WriteLine(p1);
             p1 = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
             Console.WriteLine(p1);
             p1 = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
             Console.WriteLine(p1);
         }
