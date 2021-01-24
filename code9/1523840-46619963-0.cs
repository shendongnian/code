            // Validate using:
            // 1. ValidationAttributes attached to this validatable's class, and
            // 2. ValidationAttributes attached to the properties of this validatable's class, and 
            // 3. this.Validate( validationContext)
            // 
            // Note, for entities, a NotSupportedException will be thrown by TryValidateObject if any of 
            // the primary key fields are changed. Correspondingly the UI should not allow modifying 
            // primary key fields. 
            ValidationContext validationContext = new ValidationContext(this);
            List<ValidationResult> validationResults = new List<ValidationResult>(64);
            bool isValid = Validator.TryValidateObject( this, validationContext, validationResults, true);
            Debug.Assert(isValid == (validationResults.Count == 0));
