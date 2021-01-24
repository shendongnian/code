    public class DicModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Dictionary<string, string>))
            {
                return false;
            }
            var val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (val == null)
            {
                return false;
            }
            string key = val.RawValue as string;
            if (key == null)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Wrong value type");
                return false;
            }
            string errorMessage;
            try
            {
                var jsonObj = JObject.Parse(key);
                bindingContext.Model = jsonObj.ToObject<Dictionary<string, string>>();
                return true;
            }
            catch (JsonException e)
            {
                errorMessage = e.Message;
            }
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Cannot convert value: " + errorMessage);
            return false;
        }
    }
