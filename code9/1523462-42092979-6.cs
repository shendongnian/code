    public class MyDateTimeModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(DateTime))
                return false;
            
            var time = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (time == null)
                bindingContext.Model = default(DateTime);
            else
                bindingContext.Model = DateTime.Parse(time.AttemptedValue.Replace(".", ":"));
            return true;
        }
    }
