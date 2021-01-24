    void Main()
    {
    	List<LedgerAccount> account = new List<UserQuery.LedgerAccount>()
    	{
    		new LedgerAccount() { AccountNumber = "1234-0001", BalanceDate = new DateTime(2017, 8, 8), Value = 100 },
    		new LedgerAccount() { AccountNumber = "1234-0002", BalanceDate = new DateTime(2017, 8, 8), Value = 250 },
    		new LedgerAccount() { AccountNumber = "1234-0003", BalanceDate = new DateTime(2017, 8, 8), Value = 500 },
    		new LedgerAccount() { AccountNumber = "1234-0004", BalanceDate = new DateTime(2017, 8, 8), Value = 150 },
    		new LedgerAccount() { AccountNumber = "1234-0001", BalanceDate = new DateTime(2017, 8, 9), Value = 110 },
    		new LedgerAccount() { AccountNumber = "1234-0002", BalanceDate = new DateTime(2017, 8, 9), Value = 230 },
    		new LedgerAccount() { AccountNumber = "1234-0003", BalanceDate = new DateTime(2017, 8, 9), Value = 400 },
    		new LedgerAccount() { AccountNumber = "1234-0001", BalanceDate = new DateTime(2017, 8, 10), Value = 120 },
    		new LedgerAccount() { AccountNumber = "1234-0002", BalanceDate = new DateTime(2017, 8, 10), Value = 210 },
    	};
    	
    	account.GroupBy(m => m.AccountNumber).Select(m => m.OrderByDescending(s => s.BalanceDate).FirstOrDefault()).Dump();
    }
    
    public class LedgerAccount
    {
    	public string AccountNumber { get; set; }
    	public DateTime BalanceDate { get; set; }
    	public int Value { get; set; }
    }
