    [ContractClassFor(typeof(IAccount))]
    internal abstract class Account_Contract : IAccount
    {
        //In order to implement IAccount interface, must be public
        public int AccountID
        {
            get
            {
                Contract.Requires(AccountID > 0);
                return default(int);
            }
        }
        //In order to implement IAccount interface, must be public
        public string AccountOwner
        {
            get
            {
                Contract.Ensures(!String.IsNullOrEmpty(Contract.Result<string>()));
                return default(string);
            }
        }
        //In order to implement IAccount interface, must be public
        public int GetAccountID()
        {
            Contract.Ensures(Contract.Result<int>() > 0);
            return default(int);
        }
    }
    [ContractClass(typeof(Account_Contract))]
    public interface IAccount
    {
        int AccountID { get; }
        string AccountOwner { get; }
        int GetAccountID();             ////Our 'internal'unique identifier for this account
    }
