    using MyTested.AspNetCore.Mvc.DependencyInjection;
    [Test]
    public void Post_Should_Create_A_Single_UserProfile()
    {
        // Arrange
        var profile = Dummy.GenerateCreateUserProfileDto();
        MyMvc
        .Controller<UserProfilesController>()
        .WithOptions(options => options
            .For<AppSettings>(settings => settings.Cache = true))
        .Calling(c => c.Post(profile))
        .ShouldReturn()
        .Ok()
    }
