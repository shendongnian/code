    public class TestRequestModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(TestRequest)) return false;
            bindingContext.Model = new TestRequest();
            var parameters = actionContext.Request.RequestUri.ParseQueryString();
            typeof(TestRequest)
                .GetProperties()
                .ToList()
                .ForEach(property =>
                {
                    var parameterValue = parameters[property.Name];
                    if (parameterValue == null) return;
                    typeof(TestRequest).GetProperty(property.Name).SetValue(bindingContext.Model, Convert.ChangeType(parameterValue, property.PropertyType));
                });
            return bindingContext.ModelState.IsValid;
        }
    }
