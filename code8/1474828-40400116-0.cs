    public static IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> ValidateModel<T>(T model) where T : class, new()
    {
        model = model ?? new T();
    
        var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(model);
    
        var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
    
        Validator.TryValidateObject(model, validationContext, validationResults, true);
    
        return validationResults;
    }
