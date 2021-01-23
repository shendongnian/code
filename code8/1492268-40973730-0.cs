    public abstract class PaginationModelBinder : IModelBinder
    {
            public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
            {
                  var model = (PagingParamsVM)bindingContext.Model ?? new PagingParamsVM();
                  //model population logic
                  .....
    
                  bindingContext.Model = model;
                  
                  //following lines invoke default validation on model
                  bindingContext.ValidationNode.ValidateAllProperties = true;
                  bindingContext.ValidationNode.Validate(actionContext);
                  
                  return true;
            }
    }
