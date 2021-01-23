            public ValidationResult Method1(int number, string family)
            {
                return Validate(number > 10 || family == "akbari", "Invalid Number");
            }
    
            public ValidationResult Method1(string name)
            {
                return Validate(name.Length > 20, "Invalid name");
            }
    
            public ValidationResult Method1(double average)
            {
                return Validate(average < 14, "Invalid average");
            }
    
            public ValidationResult Validate(bool predicate, string message)
            {
                var validationResult = new validationResult();
                if (predicate)
                {
                    validationResult.Errors.Add(new ValidationFailure("", message));
                }
                return validationResult;
            }
