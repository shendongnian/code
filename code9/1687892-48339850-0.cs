    public bool IsValid()
    {
        var validator = ValidationFactory.CreateValidator<YourViewModel>();
        return validator.Validate(this).IsValid;
    }
