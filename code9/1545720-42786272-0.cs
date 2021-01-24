    public class Account
    {
    }
    public class SpecificationBase<T>
    {
    }
    public class AccountSearch : SpecificationBase<Account>
    {
    }
    public class SearchBase<T> where T : SpecificationBase<Account>
    {
    }
    public class Start
    {
        public Start()
        {
            new SearchBase<AccountSearch>();
        }
    }
}
