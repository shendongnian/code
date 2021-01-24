    [Fact]
    public void ProfileRepository_GetSettingsForUserIDWithInvalidArguments_ThrowsArgumentException()
    {
        //arrange
        ProfileRepository profiles = new ProfileRepository();
        // act & assert
        Assert.Throws<ArgumentException>(() => profiles.GetSettingsForUserID(""));
    }
