        public static ValidationResult AnimalEpcValidate(object obj, ValidationContext context)
        {
            var aevm = context.ObjectInstance as ViewModel;
            // get errors from Animal validation
            var animalErrors = aevm.Animal.GetErrors("Epc")?.Cast<string>();
            // add errors from Animal validation to your Epc validation results
            var error = animalErrors?.Aggregate(string.Empty, (current, animalError) => current + animalError);
            // return aggregated errors of Epc property
            return string.IsNullOrEmpty(error)
                       ? ValidationResult.Success
                       : new ValidationResult(error, new List<string> { "Epc" });
        }
