    public class JsonToParametersAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var stream = filterContext.HttpContext.Request.InputStream;
            stream.Position = 0;
            using (var sr = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(sr))
            {
                var serializer = new JsonSerializer();
                var body = serializer.Deserialize<JObject>(jsonTextReader);
                if (body == null) return;
                foreach (var parameter in filterContext.ActionParameters)
                {
                    var jsonProperty = body.Properties()
                        .SingleOrDefault(p => p.Name == parameter.Key);
                    if (jsonProperty != null)
                    {
                        filterContext.ActionParameters[parameter.Key] = jsonProperty.Value;
                    }
                }
            }
        }
    }
