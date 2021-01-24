    //im using Constants.StoreName - you know what it is..
    
    //
    //save users
    //
    List<MyUsers> MyList; // <==users here initially
    var jsonUsers = await Task.Run(() => JsonConvert.SerializeObject(MyList));
    Account account = new Account();
    account.Username = "AllMyUsers";
    account.Properties.Add("users", jsonUsers);
    //cleanup previous
    var accounts = store.FindAccountsForService(Constants.StoreName).ToList();
    accounts.ForEach(acc => store.Delete(acc, Constants.StoreName));
    //save finally
    await store.SaveAsync(account, Constants.StoreName);
    
    //
    //read users
    //
     Account account = store.FindAccountsForService(Constants.StoreName).FirstOrDefault();
    if (account == null)
                {
                    //create new empty list of users
                    //todo
                    return false;
                }
                try
                {
                List<MyUsers> MyList = JsonConvert.DeserializeObject<List<MyUsers>>(account.Properties["users"]);
    //todo check stuff if list is valid
    return true;
                }
                catch
                {
    //todo
    //create new empty list
    //something went wrong
    
    
                }
