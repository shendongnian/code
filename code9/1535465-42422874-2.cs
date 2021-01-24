    public class AccountManager
    {
       public long UserCode { get; set; }
       public string UserName { get; set; }
    }
    public class AccountManagersVM
    {
       public ObservableCollection<AccountManager> AccountManagers{ get; set; }
    
    }
