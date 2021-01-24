    private static string objPersonFilter = "objectCategory=person";
    private static string classUserFilter = "objectClass=user";
    private static string AccountEnabledFilter = "!userAccountControl:1.2.840.113556.1.4.803:=2";
    private static string pwdExpiringMinimum = $"pwdLastSet<={DateTime.Today.AddDays(-80).ToFileTime()}";
    private static string pwdExpiringMaximum = $"pwdLastSet>={DateTime.Today.AddDays(-90).ToFileTime()}";
    private static string pwdChangedToday = $"pwdLastSet>={DateTime.Today.ToFileTime()}";
    
    private string expiringPasswordFilter = 
        $"(&({objPersonFilter})({classUserFilter})({AccountEnabledFilter})(|({pwdChangedToday})(&({pwdExpiringMinimum})({pwdExpiringMaximum}))))";
