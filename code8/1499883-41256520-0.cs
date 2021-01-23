      public bool ValidateProperties()
      {
          var propertiesWithChangedErrors = new List<string>();
          // Get all the properties decorated with the ValidationAttribute attribute.
          var propertiesToValidate = _entityToValidate.GetType()
                                                      .GetRuntimeProperties()
                                                      .Where(c => c.GetCustomAttributes(typeof(ValidationAttribute)).Any());
          ...
      }
