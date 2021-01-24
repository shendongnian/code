    public class Customer
    {
        private Dictionary<AccountType, BankAccount> accounts;
        public Customer()
        {
            this.accounts = new Dictionary<AccountType, BankAccount>();
        }
        public string Name {get;set;}	
        public Dictionary<AccountType, BankAccount> Accounts
        {
            get
            {
                return this.accounts;	
            }
        }
        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(string.Format("Customer Name : {0}{1}", this.Name, Environment.NewLine));
            output.Append(string.Format("Accounts details {0}", Environment.NewLine));
            foreach(var account in this.accounts)
            {
                output.Append(account.Value.ToString());
            }
            return output.ToString();
        }
    }
