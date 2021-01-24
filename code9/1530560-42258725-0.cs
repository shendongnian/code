    public class HttpOdometerPostedFileBaseModelBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                if(controllerContext == null)
                    throw new ArgumentNullException(nameof(controllerContext));
    
                if(bindingContext == null)
                    throw new ArgumentNullException(nameof(bindingContext));
    
                HttpPostedFileBase theFile = controllerContext.HttpContext.Request.Files[bindingContext.ModelName];
    
                return theFile;
            }
        }
