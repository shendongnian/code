    [Theory]
    [InlineData("1.25hr projectA")]
    [InlineData("1hr projectA")]
    [InlineData("projectA")]
    public void Can_parse_project_name(string rawValue)
    {
        var projectName= Regex.Replace(rawValue, @"^[\d|.|hr]+", "").Trim();
        projectName.Should().Be("projectA");
    }
