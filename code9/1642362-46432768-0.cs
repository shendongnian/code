    public class Binder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var model = new HostInfo();
            bindingContext.Model = model;
            model.Name = Convert.ToString(bindingContext.ValueProvider.GetValue("host_name").RawValue);
            if(bindingContext.ValueProvider.ContainsPrefix("host_id"))
                model.Id = Convert.ToInt32(bindingContext.ValueProvider.GetValue("host_id").RawValue);
            return true;
        }
    }
