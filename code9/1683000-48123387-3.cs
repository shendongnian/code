    public void ValidatePostalCode_ReturnsTrueWhenRegexIsNull()
    {
        var regexProvider = new PostalCodeRegexProviderThatReturnsNull();
        var subject = new PostalCodeValidator(regexProvider);
        Assert.IsTrue(subject.ValidatePostalCode("xyz","abc"));
    }
