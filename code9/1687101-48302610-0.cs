    var newObj =  new List.Configuration
    {
        ClientSiteId = 0,
        APIUserName = "Name",                   
        APIPassword = "Password"
    }
    // ...
    var item = dbSet.SingleOrDefault(x => x.ClientSiteId == newObj.ClientSiteId);
    if(item == null) {
        dbSet.Add(newObj);
    } else {
        // do something graceful, like tell the user
    }
