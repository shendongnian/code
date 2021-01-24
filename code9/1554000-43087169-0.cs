    public class MyModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            // Extract the posted data from the request
            // Convert the base64string to Stream
            // Extract the model from the bindingcontext
            // Assign the model's property with their values accordingly   
        }
    }
