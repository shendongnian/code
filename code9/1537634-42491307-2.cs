     public ActionResult About(Aboute model)
            {
                var validationResults = new List<ValidationResult>();
                // Clear ModelState check after validate
                ModelState.Clear();
                // Get validate ErrorMessage and status if you need.
                bool isValid = Validator.TryValidateObject(
                    model,
                    new ValidationContext(model, null, null),
                    validationResults,
                    true);
              // Check View Model validation and set modelState    
              TryValidateModel(model);
    
               // if(ModelState.IsValid) check state should be false
               return View(model)
            }
