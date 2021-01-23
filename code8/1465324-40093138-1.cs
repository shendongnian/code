    [TestMethod]
    public void ReturnDefaulThemeNametIfThemeIsResponsive() {
        //Arrange
        var key = "defaultTheme";
        var expected = "defaultThemeResponsive";
        var mockSettings = new Mock<IThemeSettings>();
        mockSettings.Setup(m => m.Contains(key)).Returns(true);
        mockSettings.Setup(m => m[key]).Returns(expected);
        //In production you would also do something like this with
        //the actual production implementation, not a mock
        Themes.Configure(() => mockSettings.Object);
        var theme = new Theme { isResponsive = true };
        //Act
        var defaultName = Themes.GetDefaultName(theme.isResponsive);
        //Assert
        Assert.AreEqual(expected, defaultName);
    }
