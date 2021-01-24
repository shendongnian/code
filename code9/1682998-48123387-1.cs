    [TestMethod]
    public void ValidatePostalCode_ReturnsTrueWhenRegexIsNull()
    {
        var mock = new Mock<IPostalCodeRegexProvider>();
        mock.Setup(x => x.GetPostalCodeRegex(It.IsAny<string>())).Returns(default(string));
        var subject = new PostalCodeValidator(mock.Object);
        Assert.IsTrue(subject.ValidatePostalCode("xyz","abc"));
    }
