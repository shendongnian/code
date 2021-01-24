     class Program
    {
        public static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            Account a1 = new Account { Name = "Peter", Password = "lalala", Mail = "mail@yahoo.com", TotalSold = 100M };
            accounts.Add(a1);
        }
    }
    public class Account
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public decimal TotalSold { get; set; }
    }
