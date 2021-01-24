    public class CustomModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            ObjToPass obj = new ObjToPass();
            var parameter =HttpUtility.ParseQueryString(HttpUtility.UrlDecode(actionContext.Request.Content.ReadAsStringAsync().Result).Remove(0,4));
            var res = parameter.ToString().Split('&');
            obj.Id = Convert.ToInt32(res[0].Split('=')[1]);
            obj.Name = res[1].Split('=')[1];
            bindingContext.Model = obj;
            //obj.Id = Convert.ToInt32(bindingContext.PropertyMetadata.Values[0]);
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
