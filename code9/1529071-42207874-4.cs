    public class Bank {
        string name;
        int accountIds = 0;
        List<Account> accounts = new List<Account>();
    
        public Bank(string bankName) {
            name = bankName;
        }
        //Open an account and return the account number
        //Using optional parameters to allow
        //OpenAccount("Name", "LastName", "HouseNumber", "PostalCode");
        //OpenAccount("Name", "LastName", "HouseNumber", "PostalCode", Balance, Minimum);
        public Account OpenAccount(string Name, string LastName, string HouseNumber, string PostalCode, int Balance = 0, int Min = 0) {
            var newAccount = new Account(++accountIds) {
                Name = Name;
                LastName = LastName;
                HouseNumber = HouseNumber;
                PostalCode = PostalCode;
                Balance = Balance;
                Min = Min;
            };
            accounts.Add(newAccount);
            return newAccount;    
        }
    }
