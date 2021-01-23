            public class FilterParamsModelBinder : IModelBinder
            {
                public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
                {
                    if (bindingContext.ModelType != typeof(FilterParams)) return false;
    
                    Dictionary<string, string> result = new Dictionary<string, string>();
    
                    var parameters = actionContext.Request.RequestUri.Query.Substring(1);
            
                    if(parameters.Length == 0) return false;
            
                    var regex = new Regex(@"filter\[(?<key>[\w]+)\]=(?<value>[\w^,]+)");
            
                    parameters
                        .Split('&')
                        .ToList()
                        .ForEach(_ =>
                        {
                            var groups = regex.Match(_).Groups;
    
                            if(groups.Count == 0)
                                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Cannot convert value.");
    
                            result.Add(groups["key"].Value, groups["value"].Value);
                        });
    
                    bindingContext.Model = new FilterParams { Filter = result};
    
                    return bindingContext.ModelState.IsValid;
                }
            }
