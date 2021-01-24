    [TestClass] //<--- Test classes must have this attribute to discover test methods
    public class AccountTests {
        IDatabase MockDatabase;
        [TestInitialize]
        public void Arrange() {
            
            var accounts = new List<Account>
            {
                new Checking( new Customer(1, "Alex", "Parrish"), 12, 30.00M ),
                new Savings( new Customer(2, "Alex", "Russo"), 12, 29.00M ),
                new Checking( new Customer(3, "Emma", "Swan"), 12, 30.00M ),
                new Savings( new Customer(4, "Henry", "Mills"), 12, 30.00M )
            };
            var dataMock = new Mock<IDatabase>();
            dataMock.Setup(_ => _.GetAccounts()).Returns(accounts);
            //...code removed for brevity
            MockDatabase = dataMock.Object;
        }
        [TestMethod]
        public void GetAccounts() {
            var testAccount = this.MockDatabase.GetAccounts();
            Assert.IsNotNull(testAccount);
            Assert.AreEqual(4, testAccount.Count);
        }
    
        //...code removed for brevity
    }
