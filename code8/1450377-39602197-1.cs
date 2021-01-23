    [ReplacementInExpressionTrees(MethodName=nameof(ExpressionsHelper.ToProfileViewModel))]
    public static ProfileModel ToViewModel(this Profile profile)
    {
        // this implementation is only here, so that if you call the method in a non expression tree, it will still work
        return ExpressionsHelper.ToProfileViewModel().Compile()(profile); // tip: cache the compiled func!
