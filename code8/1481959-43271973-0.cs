    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var descriptor = actionContext.ActionDescriptor;
            var modelState = actionContext.ModelState;
    
            if (descriptor != null)
            {
                var parameters = descriptor.GetParameters();
    
                var subParameterIssues = modelState.Keys
                                                   .Where(s => s.Contains("."))
                                                   .Where(s => modelState[s].Errors.Any())
                                                   .GroupBy(s => s.Substring(0, s.IndexOf('.')))
                                                   .ToDictionary(g => g.Key, g => g.ToArray());
    
                foreach (var parameter in parameters)
                {
                    var argument = actionContext.ActionArguments[parameter.ParameterName];
    
                    if (subParameterIssues.ContainsKey(parameter.ParameterName))
                    {
                        var subProperties = subParameterIssues[parameter.ParameterName];
                        foreach (var subProperty in subProperties)
                        {
                            var propName = subProperty.Substring(subProperty.IndexOf('.') + 1);
                            var property = parameter.ParameterType.GetProperty(propName);
                            var validationAttributes = property.GetCustomAttributes(typeof(ValidationAttribute), true);
    
                            var value = property.GetValue(argument);
    
                            modelState[subProperty].Errors.Clear();
                            foreach (var validationAttribute in validationAttributes)
                            {
                                var attr = (ValidationAttribute)validationAttribute;
                                if (!attr.IsValid(value))
                                {
                                    var parameterName = GetParameterName(property);
                                    // modelState.AddModelError(subProperty, attr.FormatErrorMessage(parameterName));
                                    modelState.AddModelError(parameterName, attr.FormatErrorMessage(parameterName));
                                }
                            }
                        }
                    }
    
    
                }
            }
    
        }
    
        private string GetParameterName(PropertyInfo property)
        {
            var dataMemberAttribute = property.GetCustomAttributes<DataMemberAttribute>().FirstOrDefault();
            if (dataMemberAttribute?.Name != null)
            {
                return dataMemberAttribute.Name;
            }
    
            var jsonProperty = property.GetCustomAttributes<JsonPropertyAttribute>().FirstOrDefault();
            if (jsonProperty?.PropertyName != null)
            {
                return jsonProperty.PropertyName;
            }
    
            return property.Name;
        }
    }
