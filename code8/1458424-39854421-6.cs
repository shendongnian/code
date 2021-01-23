    public class ServiceTests
    {
        private readonly string _email;
        private readonly string _subject;
        private readonly string _message;
        private readonly ApplicationUser _applicationUser;
        private readonly Mock<ITokenGenerator> _tokenGenerator;
        public ServiceTests()
        {
            _email = "me@gmail.com";
            _subject = "test from me";
            _message = "hello I got to you";
            _applicationUser = new ApplicationUser { UserName = _email, Email = _email };
            _tokenGenerator = Mock<ITokenGenerator>();
        }
        [Fact]
        public async Task GenerateConfirmationToken()
        {
            // #### Setup ####
            // Reads: If GenerateToken method is called with the **exact** same instance as the user passed to the service
            _tokenGenerator.Setup(t => t.GenerateToken(It.Is(user)))
                // then return "abc123456" as token
                .Returns("abcd123456")
                // Verify that the method is called with the exact conditions from above, otherwise fail
                // i.e. if GenerateToken is called with a different instance of user, test will fail
                .Verifiable("ContainsKey not called.");
            // #### ACT ####
            // Pass the token generator mock to our account service
            var _accountService = new AccountService(_tokenGenerator.Object);
            var register = await _accountService.Register(_applicationUser, "password");
            var token = await _accountService.GenerateEmailConfirmationTokenAsync(userMock.Object.First());
            // #### VERIFY ####
            // Verify that GenerateToken method has been called with correct parameters
            _tokenGenerator.Verify();
            // verify that the GenerateEmailConfirmationTokenAsync returned the expected token abc123456
            Assert.Equals(token, "abcd123456");
        }
