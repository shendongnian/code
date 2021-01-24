    public static TestCaseData AddArguments(this TestCaseData source, params object[] args)
    {
        var arguments = source.Arguments.Concat(args).ToArray();
        return new TestCaseData(arguments);
    }
