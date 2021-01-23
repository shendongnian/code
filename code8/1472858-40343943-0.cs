    private bool Validate(params Control[] controls)
    {
       bool result = controls == null || !controls.Any();
    
       if (controls != null)
       {
           DXValidationProvider provider = new DXValidationProvider { ValidationMode = ValidationMode.Auto };
           ConditionValidationRule noEmptyValues = new ConditionValidationRule
           {
               ConditionOperator = ConditionOperator.IsNotBlank,
               ErrorText = @"You must enter a value",
               ErrorType = ErrorType.Critical
           };
    
           foreach (Control control in controls)
           {
              provider.SetValidationRule(control, noEmptyValues);
           }
    
           result = provider.Validate(); //Validate all controls associated with the provider
        }
    
       return result;
     }
