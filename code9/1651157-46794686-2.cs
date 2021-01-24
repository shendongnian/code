    public abstract class Account
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
    
    public class Asset : Account { }
    public class Debt : Account { }
    // in option #3
    accountList.OfType<Asset>().Sum(x => x.Balance);
