        public class Account : NewType<Account, Unit>
        {
            public Account(Unit _) : base(unit)
            { }
        }
        Either<Exception, Account> GetAccountWithID(int accountId)
        {
            return Account.New(unit);
        }
        Task<Either<Exception, bool>> Initialize(Account c)
        {
            return Task.FromResult(Right<Exception, bool>(true));
        }
        [Fact]
        public void StackOverflowQuestion()
        {
            int accountID = 0;
            var res = GetAccountWithID(accountID)
                .Map(c => Initialize(c))
                .Bind(t => t.Result);
        }
