    var validateranges = new[]
    {
        new ValidateRanges(new[] {new Range(0, 100), ValidationMethod1}),
        new ValidateRanges(new[] {new Range(101, 200), ValidationMethod2}),
        new ValidateRanges(new[] {new Range(201, 500), ValidationMethod3}),
    };
    foreach (var validation in validateranges.Where(val => val.IsInRange(value)))
    {
        return validation.Validate();
    }
    return false; // default validation
