    [TestFixture]
    public class TokenServiceTests
    {
        private readonly IConfiguration _configuration;
        public TokenServiceTests()
        {
            var settings = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("JWT:Issuer", "TestIssuer"),
                new KeyValuePair<string, string>("JWT:Audience", "TestAudience"),
                new KeyValuePair<string, string>("JWT:SecurityKey", "TestSecurityKey")
            };
            var builder = new ConfigurationBuilder().AddInMemoryCollection(settings);
            this._configuration = builder.Build();
        }
        [Test(Description = "Tests that when [GenerateToken] is called with a null Token Service, an ArgumentNullException is thrown")]
        public void When_GenerateToken_With_Null_TokenService_Should_Throw_ArgumentNullException()
        {
            var service = new TokenService(_configuration);
            Assert.Throws<ArgumentNullException>(() => service.GenerateToken(null, new List<Claim>()));
        }
    }
