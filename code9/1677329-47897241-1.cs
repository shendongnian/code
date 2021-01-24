    public class AccountsByNameComparer : IComparer<Account>
    {
        private readonly string _name;
        public AccountsByNameComparer(string name)
        {
            _name = name;
        }
        public int Compare(Account x, Account y)
        {
            return AccountSortValue(x).CompareTo(AccountSortValue(y));
        }
        private int AccountSortValue(Account account)
        {
            if (account.PersonRoles.Any(role => role.AccountRoleCode == "O"
                                                && role.Name == _name)) return 0;
            if (account.PersonRoles.Any(role => role.AccountRoleCode == "CO"
                                                && role.Name == _name)) return 1;
            if (account.PersonRoles.Any(role => role.AccountRoleCode == "BE"
                                                && role.Name == _name)) return 2;
            return 3;
        }
    }
