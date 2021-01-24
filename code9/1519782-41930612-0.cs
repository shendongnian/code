        public class ResetSerializeContractResolverFilter : System.Web.Http.Filters.ActionFilterAttribute
        {
        public ResetSerializeContractResolverFilter()
        {
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            json.SerializerSettings.ContractResolver = new DefaultContractResolver();
            base.OnActionExecuting(actionContext);
        }
        }
