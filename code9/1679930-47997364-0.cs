    class Account
    {
        public int AccountNumber { get; set; }
        public Role[] Roles { get; set; }
    }
    
    class Role
    {
        public string State { get; set; }
        public int RoleOrder { get; set; }
    }
    
    Account[] accounts = new Account[3];
            accounts[0] = new Account { AccountNumber = 1, Roles = new 
    Role[2] { new Role { State = "AK", RoleOrder = 2 }, new Role { State = 
    "CO", RoleOrder = 1 } } };
            accounts[1] = new Account { AccountNumber = 3, Roles = new 
    Role[2] { new Role { State = "NY", RoleOrder = 66 }, new Role { State = 
    "FL", RoleOrder = 5 } } };
            accounts[2] = new Account { AccountNumber = 2, Roles = new 
    Role[2] { new Role { State = "CA", RoleOrder = 9 }, new Role { State = 
    "AZ", RoleOrder = 8 } } };
    IEnumerable<Account> info = accounts
        .Select(x => new Account { 
            AccountNumber = x.AccountNumber
            , Roles = x.Roles.OrderBy(y => y.RoleOrder).ToArray() 
        }
        ).Where(x => x.AccountNumber == 2);
