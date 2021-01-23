    public class ServiceTests
    {
        private readonly string _email;
        private readonly string _subject;
        private readonly string _message;
        private readonly Mock<IAccountService> _accountService;
        private readonly ApplicationUser _applicationUser;
        private readonly Mock<VisualJobsDbContext> _identityDbContext;
        public ServiceTests()
        {
            _email = "me@gmail.com";
            _subject = "test from me";
            _message = "hello I got to you";
            _applicationUser = new ApplicationUser { UserName = _email, Email = _email };
        }
        [Fact]
        public async Task GenerateConfirmationToken()
        {
            // Does it have dependencies? If yes, you may need to mock them
            var _accountService = new AccountService(.../*mocked dependencies*/);
            var register = await _accountService.Register(_applicationUser, "password");
            var token = await _accountService.GenerateEmailConfirmationTokenAsync(userMock.Object.First());
            Assert.NotNull(token);
        }
