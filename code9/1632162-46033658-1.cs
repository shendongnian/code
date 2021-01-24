    public static void ThrowIfInvalid(IEnumerable<ValidationError> errors)
    {
        if(errors == null)
           return;
        var e = errors.ToList();
        if(e.Any())
        {
            throw new Exception(\*use 'e' here to form exception*\);
        }
    }
