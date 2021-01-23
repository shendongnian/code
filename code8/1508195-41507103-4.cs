    [ContractClassFor(typeof(IAccount))]
    internal abstract class Account_Contract : IAccount
    {
        int IAccount.AccountID
        {
            get
            {
                //You must cast this as IAccount
                Contract.Requires(((IAccount)this).AccountID > 0);
                return default(int);
            }
        }
        string IAccount.AccountOwner
        {
            get
            {
                Contract.Ensures(!String.IsNullOrEmpty(Contract.Result<string>()));
                return default(string);
            }
        }
        public int GetAccountID()
        {
            Contract.Ensures(Contract.Result<int>() > 0);
            return default(int);
        }
    }
