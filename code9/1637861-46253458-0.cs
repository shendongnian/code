    public override void OnActionExecuting(HttpActionContext actionContext) {
        foreach (var actionArgument in actionContext.ActionArguments.ToList()) {
            if (actionArgument.Value != null && actionArgument.Value is string) {
                var sanitizedString = actionArgument.Value.ToString().Trim();
                sanitizedString = Regex.Replace(sanitizedString, @"\s+", " ");
                actionContext.ActionArguments[actionArgument.Key] = sanitizedString;
            } else {
                var properties = actionArgument.Value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(x => x.CanRead && x.PropertyType == typeof(string) && x.GetGetMethod(true).IsPublic && x.GetSetMethod(true).IsPublic);
                foreach (var propertyInfo in properties) {
                    var sanitizedString = propertyInfo.GetValue(actionArgument.Value).ToString().Trim();
                    sanitizedString = Regex.Replace(sanitizedString, @"\s+", " ");
                    propertyInfo.SetValue(actionArgument.Value, sanitizedString);
                }
            }
        }
    }
