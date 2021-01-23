    internal class GenericModelBinder<T> : IModelBinder where T : class, new()
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof (T))
            {
                return false;
            }
    
            var model = (T) bindingContext.Model ?? new T();
    
            JObject @object = null;
    
            var task = actionContext.Request.Content.ReadAsAsync<JObject>().ContinueWith(t => { @object = t.Result; });
            task.Wait();
    
            var jsonString = @object.ToString(Formatting.None);
            JsonConvert.PopulateObject(jsonString, model);
            bindingContext.Model = model;
    
            return true;
        }
    }
