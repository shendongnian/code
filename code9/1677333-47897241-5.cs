    public class AccountsByNameComparer : IComparer<Account>
    {
        private readonly string _name;
        private readonly List<string> _preferredRoleSequence;
        public AccountsByNameComparer(string name, IEnumerable<string> preferredRoleSequence)
        {
            _name = name;
            _preferredRoleSequence = preferredRoleSequence.ToList();
        }
        public int Compare(Account x, Account y)
        {
            return AccountSortValue(x).CompareTo(AccountSortValue(y));
        }
        private int AccountSortValue(Account account)
        {
            var rolesMatchedByName = account.PersonRoles
                .Where(role => role.Name == _name);
            var preferredRoleMatches =
                rolesMatchedByName.Select(role => 
                    _preferredRoleSequence.IndexOf(role.AccountRoleCode))
                        .Where(index => index > -1)
                        .ToArray();
            if (preferredRoleMatches.Any())
                return preferredRoleMatches.Min();
            return Int32.MaxValue;
        }
    }
    public class ExecutiveAccountsByNameComparer : AccountsByNameComparer
    {
       public ExecutiveAccountsByNameComparer(string name)
            :base(name, new []{"O", "CO", "BE" }) { }
       
    }
