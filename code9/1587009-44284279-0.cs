    Outlook.Accounts accounts = OutlookApp.Session.Accounts; 
    foreach (var acc in accounts.OfType<Outlook.Account>().OrderBy(a => a.DisplayName)) 
    { 
        var myNameSpace = OutlookApp.GetNamespace("MAPI");
    }
