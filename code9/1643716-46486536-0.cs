    // Declare binder that will convert parameters to Hashtable
    public class HashtableBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var json = bindingContext?.ValueProvider?.GetValue(bindingContext.ModelName)?.AttemptedValue as string;
            if (json != null)
            {
                //Deserialize using Microsoft's JSON serializer
                var serializer = new JavaScriptSerializer();
                bindingContext.Model = serializer.Deserialize<Hashtable>(json);
                //or deserialize using Newtonsoft JSON convertor
                //bindingContext.Model = JsonConvert.DeserializeObject<Hashtable>(json);
                return true;
            }
            return false;
        }
    }
    // In your controller, decorate parameter
    // with FromUri attribute and specify HashtableBinder
    // as BinderType
    [HttpGet]
    [Route("api/Order/RetrieveOrderList")]
    public void RetrieveOrderList([FromUri(BinderType = typeof(HashtableBinder), Name = "conditions")]Hashtable conditions)
    {
        // access hashtable in conditions parameter, e.g. var status = conditions["Status"]
    }
