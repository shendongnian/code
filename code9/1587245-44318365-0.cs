    var model = new SomeModel(); //Has DataAnnotation attributes
    var validationContext = new ValidationContext(model);
    var list = new List<ValidationResult>();
     if (!Validator.TryValidateObject(model, validationContext, list))
     {
        //Error on validation. Check the list for more details.
     }   
