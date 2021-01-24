    [TestClass]
    public class SortAccountsByNameTests
    {
        [TestMethod]
        public void AccountsAreSortedInCorrectOrder()
        {
            var account1 = new Account
            {
                PersonRoles = new PersonRole[]
                {
                    new PersonRole {AccountRoleCode = "BE", Name = "Bob"},
                    new PersonRole {AccountRoleCode = "CO", Name = "Steve"},
                    new PersonRole {AccountRoleCode = "O", Name = "John"},
                }
            };
            var account2 = new Account
            {
                PersonRoles = new PersonRole[]
                {
                    new PersonRole {AccountRoleCode = "CO", Name = "Bob"},
                    new PersonRole {AccountRoleCode = "O", Name = "Steve"},
                    new PersonRole {AccountRoleCode = "BE", Name = "John"},
                }
            };
            var account3 = new Account
            {
                PersonRoles = new PersonRole[]
                {
                    new PersonRole {AccountRoleCode = "O", Name = "Bob"},
                    new PersonRole {AccountRoleCode = "CO", Name = "Steve"},
                    new PersonRole {AccountRoleCode = "BE", Name = "John"},
                }
            };
            var account4 = new Account
            {
                PersonRoles = new PersonRole[]
                {
                    new PersonRole {AccountRoleCode = "O", Name = "Al"},
                    new PersonRole {AccountRoleCode = "CO", Name = "Steve"},
                    new PersonRole {AccountRoleCode = "BE", Name = "John"},
                }
            };
            var unsorted = new Account[] {account1, account2, account3, account4};
            var comparer = new AccountsByNameComparer("Bob");
            var sorted = unsorted.OrderBy(a => a, comparer);
            var expectedOrder = new Account[]{account3, account2, account1, account4};
            Assert.IsTrue(expectedOrder.SequenceEqual(sorted));
        }
    }
