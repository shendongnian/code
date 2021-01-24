    [Fact]
    public void ProfileRepository_GetSettingsForUserIDWithInvalidArguments_ThrowsArgumentException()
    {
        //arrange
        ProfileRepository profiles = new ProfileRepository();
        //act
        Action act = () => profiles.GetSettingsForUserID("");
        //assert
        var ex = Assert.Throws<ArgumentException>(act);
        Assert.Equal("expected error message here", ex.Message);
    }
