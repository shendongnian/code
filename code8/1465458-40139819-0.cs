    using Microsoft.Extensions.Options;
    [Test]
    public void Post_Should_Create_A_Single_UserProfile()
    {
        // Arrange
        var profile = Dummy.GenerateCreateUserProfileDto();
        var mockedSettings = new AppSettings
        {
             MyValue = "the test value"
        }
        MyMvc
        .Controller<UserProfilesController>()
        .WithResolvedDependencyFor<IOptions<AppSettings>>(Options.Create(mockedSettings))
        .Calling(c => c.Post(profile))
        .ShouldReturn()
        .Ok()
    }
