    void Main()
    {
        var accountList = new AccountList();
        //Save a few accounts to the file
        Account a1 = new Account("Google", "GoogleEmail", "GoogleUser", "GooglePass");
        accountList.Add(a1);
        Account a2 = new Account("Netflix", "NetflixEmail", "NetflixUser", "NetflixPass");
        accountList.Add(a2);
        
        AccountList.SaveToFile(@"g:\test\accounts.txt", accountList);
        
        //Load the accounts from the file
        AccountList aList2 = AccountList.ReadFromFile(@"g:\test\accounts.txt");
        aList2.Dump();
    }
    
    public class AccountList
    {
        private List<Account> accounts;
        public IEnumerable<Account> Accounts { get { return accounts;} }
        
        public AccountList()
        {
            this.accounts = new List<Account>();
        }
    
        public void Add(Account a)
        {
            accounts.Add(a);
        }
    
        public static void SaveToFile(string filename, AccountList accounts)
        {
            //Selects all the `Account` instances and creates a string[]
            System.IO.File.WriteAllLines(filename, accounts.Accounts.Select(a => $"{a}").ToArray());
        }
    
        public static AccountList ReadFromFile(string filename) // this is meant to be used as authentication in my main form, it isn't necessary right now..
        {
            var result = new AccountList();
    
            //Read each line from the file and create an Account instance.
            foreach (var line in System.IO.File.ReadAllLines(filename))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        Account a = new Account(parts[0], parts[1], parts[2], parts[3]);
                        result.Add(a);
                    }
                }
            }
    
            return result;
        }
    }
    
    public class Account
    {
        public string Domain; //this is supposed to be google/skype/facebook
        public string Email;
        public string Username;
        public string Password;
    
        public Account(string domain, string email, string username, string password)
        {
            Domain = domain;
            Email = email;
            Username = username;
            Password = password;
        }
    
        public override string ToString()
        {
            return $"{Domain},{Email},{Username},{Password}";
        }
    }
