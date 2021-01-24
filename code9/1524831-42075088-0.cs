    static Validations()
    {
    Assembly a = typeof(ISpecialCaseRequestValidation).Assembly;
                _validationTypes =
                    a.GetTypes()
                        .Where(
                            type =>
                                type != typeof(ISpecialCaseRequestValidation) &&
                                typeof(ISpecialCaseRequestValidation).IsAssignableFrom(type))
                        .ToList();
    }
