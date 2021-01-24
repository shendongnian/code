    public class CustomModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;
            ObjToPass obj = new ObjToPass();
            ;
            try
            {
                ObjToPass s =
                    JsonConvert.DeserializeObject<ObjToPass>(actionContext.Request.Content.ReadAsStringAsync().Result,
                        settings);
                bindingContext.Model = obj;
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError("extraColumn", ex.Message);
            }
            return true;
        }
    }
    public class CustomerOrderModelBinderProvider : ModelBinderProvider
    {
        public override IModelBinder GetBinder(System.Web.Http.HttpConfiguration configuration, Type modelType)
        {
            return new CustomModelBinder();
        }
    }
    
