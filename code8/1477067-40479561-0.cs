    // System.Web.Mvc.DefaultModelBinder.SetProperty
    ....
        ModelValidator modelValidator = (from v in ModelValidatorProviders.Providers.GetValidators(modelMetadata, controllerContext)
    		where v.IsRequired
    		select v).FirstOrDefault<ModelValidator>();
    		if (modelValidator != null)
    		{
    			foreach (ModelValidationResult current in modelValidator.Validate(bindingContext.Model))
    			{
    				bindingContext.ModelState.AddModelError(key, current.Message);
    			}
    		}
    ....
