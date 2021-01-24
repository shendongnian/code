    public class JsonMultiParameterModelBinder : IModelBinder
    {
        private static IModelBinder DefaultModelBinder;
        private const string JSONKEY = "json_body";
        public JsonMultiParameterModelBinder(IModelBinder defaultModelBinder)
        {
            DefaultModelBinder = defaultModelBinder;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var httpContext = bindingContext.HttpContext;
            var stream = bindingContext.HttpContext.Request.Body;
            if (httpContext.Request.ContentType.Contains("application/json"))
            {
                JObject jobject = null;
                ModelStateEntry entry = null;
                bindingContext.ModelState.TryGetValue(JSONKEY, out entry);
                if (entry == null)
                {
                    using (var readStream = new StreamReader(stream, Encoding.UTF8))
                    using (var jsonReader = new JsonTextReader(readStream))
                    {
                        jobject = JObject.Load(jsonReader);
                    }
                    bindingContext.ModelState.SetModelValue(JSONKEY, jobject, null);
                }
                else
                {
                    jobject = entry.RawValue as JObject;
                }
                var jobj = jobject[bindingContext.FieldName];
                if (jobj == null)
                {
                    httpContext.Response.StatusCode = 500; // error has occured
                    throw new JsonReaderException(string.Format("The rootnode '{0}' is not found in the Json message.", bindingContext.ModelName));
                }
                object obj = null;
                var JSONSerializer = new JsonSerializer();
                try
                {
                    obj = jobj.ToObject(bindingContext.ModelType, JSONSerializer);
                    bindingContext.Model = obj;
                    bindingContext.Result = ModelBindingResult.Success(obj);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    httpContext.Response.StatusCode = 500; // error has occured
                    throw ex;
                }
            }
            return DefaultModelBinder.BindModelAsync(bindingContext);
        }
    }
