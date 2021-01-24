    public IEnumerable GetErrors(string propertyName)
    {
        if (propertyName == nameof(Alpha) && string.IsNullOrEmpty(Alpha))
        {
            return new []{"Alpha is null or empty"};
        }
        if (propertyName == nameof(Beta)  && string.IsNullOrEmpty(Beta))
        {
            return new []{"Beta is null or empty"};
        }
        return Enumerable.Empty<string>();
    }
