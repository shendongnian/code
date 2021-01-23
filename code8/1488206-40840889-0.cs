    class Program
    {
        public class AccountInformation
        {
            public string AccountNumber { get; set; }
            public int StartDate { get; set; }
            public int EndDate { get; set; }
        }
        static void Main(string[] args)
        {
            List<AccountInformation> accounts = new List<AccountInformation>();
            accounts.Add(new AccountInformation() { AccountNumber = "AC1", StartDate = 20150101, EndDate = 20150110 });
            accounts.Add(new AccountInformation() { AccountNumber = "AC1", StartDate = 20150110, EndDate = 20150111 });
            accounts.Add(new AccountInformation() { AccountNumber = "AC1", StartDate = 20150111, EndDate = 20150112 });
            accounts.Add(new AccountInformation() { AccountNumber = "AC2", StartDate = 20150112, EndDate = 20150115 });
            accounts.Add(new AccountInformation() { AccountNumber = "AC1", StartDate = 20150116, EndDate = 20150120 });
            accounts.Add(new AccountInformation() { AccountNumber = "AC1", StartDate = 20150121, EndDate = 20150125 });
            accounts.Add(new AccountInformation() { AccountNumber = "AC2", StartDate = 20150125, EndDate = 20150130 });
            accounts.Add(new AccountInformation() { AccountNumber = "AC2", StartDate = 20150130, EndDate = 20150205 });
            List<AccountInformation> newAccounts = new List<AccountInformation>();
            AccountInformation previousAccount = null;
            bool continous = false;
            for (int index=0;index<accounts.Count;index++)
            {
                if (null != previousAccount)
                {
                    if (accounts[index].AccountNumber.Equals(previousAccount.AccountNumber) &&
                        accounts[index].StartDate == previousAccount.EndDate)
                    {
                        continous = true;
                        if (!(continous && newAccounts.Count>0))
                        {
                            newAccounts.Add(previousAccount);
                        }
                    }
                    else
                    {
                        continous = false;
                        newAccounts.Add(accounts[index]);
                    }
                }
                previousAccount = accounts[index];
            }
        }
    }
