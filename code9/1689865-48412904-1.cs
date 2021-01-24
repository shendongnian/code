    public static class PolicyExtensions
    {
        public static bool ContainsExceptionMessage(this IEnumerable<Error> errors)
        {
            return errors.Any(error => error.Name.Contains("EXCEPTION"));
        }
    }
