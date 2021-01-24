    public static TestCaseData AddArguments(this TestCaseData source, params object[] args)
    {
        var arguments = source.Arguments.Concat(args).ToArray();
        var category = source.Properties.Get(PropertyNames.Category).ToString();
        return new TestCaseData(arguments).SetCategory(category);
    }
