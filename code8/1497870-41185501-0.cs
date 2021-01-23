        public class TestRequestModelBinder : System.Web.Http.ModelBinding.IModelBinder
        {
            public bool BindModel(HttpActionContext actionContext,
                                  System.Web.Http.ModelBinding.ModelBindingContext bindingContext)
            {
                if (bindingContext.ModelType != typeof(TestRequest)) return false;
                bindingContext.Model = new TestRequest();
                
                var parameters = actionContext.Request.RequestUri.ParseQueryString();   
                typeof(TestRequest)
                    .GetProperties()
                    .Select(property => property.Name)
                    .ToList()
                    .ForEach(propertyName =>
                    {
                        var parameterValue = parameters[propertyName];
  
                        if(parameterValue == null) return;      
                        typeof(TestRequest).GetProperty(propertyName).SetValue(bindingContext.Model, parameterValue);
                    });
                
                return bindingContext.ModelState.IsValid;
            }
        }
