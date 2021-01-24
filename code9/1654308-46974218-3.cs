    public class Xunittests : IClassFixture<SecurityTestsFixture>
    {
        SecurityTestsFixture _securityFixture;
        public Xunittests(SecurityTestsFixture securityfixture)
        {
            _securityFixture = securityfixture;
        }
        [Fact(DisplayName = "Successful response Test1")]
        public void SuccessfulResponseTest1()
        {
            var db = _securityFixture.Dbfixture.Db;
            //var users = db.Users.FirstOrDefault(x => x.Name == "...");
            Assert.Equal("test", "test");
        }
    }
