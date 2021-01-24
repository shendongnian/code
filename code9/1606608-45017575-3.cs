    [Fact]
    public void ProfileRepository_GetSettingsForUserIDWithInvalidArguments_ThrowsArgumentException()
    {
        //arrange
        ProfileRepository profiles = new ProfileRepository();
        //act
        Action act = () => profiles.GetSettingsForUserID("");
        //assert
        Assert.Throws<ArgumentException>(act);
    }
