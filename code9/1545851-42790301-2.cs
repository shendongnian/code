    public static ExceptionAssertions<TException> ShouldThrow<TException>(
        this Func<Task> asyncAction, string because = "", params object[] becauseArgs)
            where TException : Exception
        {
            return new AsyncFunctionAssertions(asyncAction, extractor)
               .ShouldThrow<TException>(because, becauseArgs);
        }
    
