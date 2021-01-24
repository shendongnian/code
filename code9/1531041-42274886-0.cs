    namespace MyTests
    {
        public class AccountObjTest
        {
            public void Test1()
            {
                int testVal = 10;
                AccountObj obj = new AccountObj(testVal, new AccountObjTestService());
                obj.RefreshAmount();        
                Assert.AreEquals(obj.Amount, testVal);
            }
        }
        internal class AccountObjTestService : IAccountService
        {
            public override double GetAmount(int accountId)
            {
                return accountId;
            }
        }
    }
