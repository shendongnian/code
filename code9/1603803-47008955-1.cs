    [TestClass]
    public class SomeControllerAPITest {
        private SmtpConfig _smtpConfig;
        public SomeControllerAPITest() {
            _smtpConfig = new TestSmtpConfigOptions().Value;
        }
        [TestMethod]
        public void Post_ReturnsCreatedInstance() {
            var credentials = _smtpConfig.credentials;
            //use that credentials
            ...
            //call remote server
            ...
        }
    }
