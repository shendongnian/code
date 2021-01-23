    public static class ExceptionExtensions
    {
        public static IEnumerable<Exception> InnerExceptionsAndSelf(this Exception ex)
        {
            while (ex != null)
            {
                yield return ex;
                ex = ex.InnerException;
            }
        }
    }
