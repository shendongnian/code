            public ValidationResult Method1(string name)
            {
                return Validate(name, (param) => param.Length > 20, "Invalid name");
            }
    
            public ValidationResult Method1(double average)
            {
                return Validate(average, (param) => param < 14, "Invalid average");
            }
    
            private ValidationResult Validate<T>(T param, Func<T, bool> predicate, string message)
            {
                var validationResult = new validationResult();
                if (predicate(param))
                {
                    validationResult.Errors.Add(new ValidationFailure("", message));
                }
                return validationResult;
            }
    
