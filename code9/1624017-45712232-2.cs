    public class JsonToParametersAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var stream = filterContext.HttpContext.Request.Body;
            using (var sr = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(sr))
            {
                var serializer = new JsonSerializer();
                var body = serializer.Deserialize<JObject>(jsonTextReader);
                if (body == null) return;
                foreach (var parameter in filterContext.ActionDescriptor.Parameters)
                {
                    var jsonProperty = body.Properties().SingleOrDefault(p => p.Name == parameter.Name);
                    if (jsonProperty != null)
                    {
                        var param = filterContext.ActionDescriptor.Parameters.OfType<ControllerParameterDescriptor>().FirstOrDefault(e => e.Name == parameter.Name);
                        if (param == null)
                        {
                            continue;
                        }
                        if (!filterContext.ActionArguments.ContainsKey(parameter.Name))
                        {
                            object value;
                            try
                            {
                                value = jsonProperty.Value.ToObject(param.ParameterInfo.ParameterType);
                            }
                            catch (Exception)
                            {
                                value = GetDefault(param.ParameterInfo.ParameterType);
                            }
                            filterContext.ActionArguments.Add(parameter.Name, value);
                        }
                    }
                }
            }
        }
        private static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
