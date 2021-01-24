    public class Account
    {
    }
    public class SpecificationBase<T>
    {
    }
    public class AccountSearch : SpecificationBase<Account>
    {
    }
    public class SearchBase<T, TModel> where T : SpecificationBase<TModel>
    {
    }
    public class Start
    {
        public Start()
        {
            new SearchBase<AccountSearch, Account>();
        }
    }
