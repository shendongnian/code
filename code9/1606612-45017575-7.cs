    [Fact]
    public void ProfileRepository_GetSettingsForUserIDWithInvalidArguments_ThrowsArgumentException()
    {
        //arrange
        ProfileRepository profiles = new ProfileRepository();
        //act
        Action act = () => profiles.GetSettingsForUserID("");
        //assert
        var exception = Assert.Throws<ArgumentException>(act);
        //The thrown exception can be used for even more detailed assertions.
        Assert.Equal("expected error message here", exception.Message);
    }
