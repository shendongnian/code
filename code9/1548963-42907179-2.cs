    public ValidationResult Update()
    {
      var validationResult = this.Validate();
    
      if (validationResult.IsValid)
      {
        // ... your code to actually update the repository goes here
      }
    
      return validationResult;
    }
