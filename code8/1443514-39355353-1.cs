    var context = new ValidationContext(command.Address.PrimitiveAddress);
    var results = new List<ValidationResult>();
    var isValid = Validator.TryValidateObject(recipe, context, results);
    
    if (!isValid)
    {
        foreach (var validationResult in results)
        {
            Console.WriteLine(validationResult.ErrorMessage);
        }
    }
