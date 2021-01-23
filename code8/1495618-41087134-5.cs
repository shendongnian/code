    var valResults = new List<ValidationResult>();
    if (!valResults.CheckIsValid1(number, family)
        || !valResults.CheckIsValid2(name)
        || // more checks... will stop if one fails
        )
    {
        return valResults.Last().Errors.First();
    }
