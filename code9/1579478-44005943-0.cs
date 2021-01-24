    public static void ThrowIfNull([ValidatedNotNull] this object value, string parameterName)
    {
        if (value == null)
        {
            throw new ArgumentNullException(parameterName);
        }
    }
