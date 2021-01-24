    public static bool IsValid(object model)
            {
                var context = new ValidationContext(model, null, null);
                var results = new List<ValidationResult>();
    
                if (Validator.TryValidateObject(model, context, results, true))
                {
                    return true;
                }
    
                return false;
            }
