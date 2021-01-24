    .Field(nameof(DepartmentName),
    validate: (state, response) =>
    {
        var value = (string)response;
        string[] departments = Enum.GetNames(typeof(Department)).ToArray();
        var feedback = $"Department name is not valid. Options:\n\n {String.Join("\n\n", departments)}";
    
        var result = new ValidateResult() { IsValid = false,                                            
                                            Feedback = feedback  };
    
        if (departments.Any(x => x.ToLower() == value))
        {
            result.IsValid = true;
            result.Feedback = null;
            result.Value = value;
        }
        return Task.FromResult<ValidateResult>(result);
    });
