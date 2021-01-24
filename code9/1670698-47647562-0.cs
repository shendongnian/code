        public bool BindModel(
             HttpActionContext actionContext,  
             System.Web.Http.ModelBinding.ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(PartyModel))
                return false;
            ...
 
            // following lines invoke default validation on model
            bindingContext.ValidationNode.ValidateAllProperties = true;
            bindingContext.ValidationNode.Validate(actionContext);
            return true;
        }
