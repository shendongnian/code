    public IEnumerable GetErrors(string propertyName)
    {
        if (propertyName == nameof(Alpha) && !AlphaIsValid)
        {
            return new []{"Alpha is null or empty"};
        }
        if (propertyName == nameof(Beta)  && !BetaIsValid)
        {
            return new []{"Beta is empty"};
        }
        return Enumerable.Empty<string>();
    }
