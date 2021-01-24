    void GetValidator(Container container, string entityName, Entity entity)
    {
        Type validatorType = typeof(IValidator<>).MakeGenericType(entity.GetType());
        dynamic validator = container.GetInstance(validatorType);
        validator.Validate((dynamic)entity);
    }
