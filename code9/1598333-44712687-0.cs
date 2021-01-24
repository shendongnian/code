    protected void Application_Start()
    {
        // Add Custom Attribute
        System.Web.Mvc.DataAnnotationsModelValidatorProvider.RegisterAdapter(
                    typeof(TestCustomValidation.CustomValidation.CustomRequiredAttribute),
                    typeof(System.Web.Mvc.RequiredAttributeAdapter));
        
    }
