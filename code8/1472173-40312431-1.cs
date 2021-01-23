        public class OptApiExplorer : ApiExplorer
    {
        public OptApiExplorer(HttpConfiguration configuration)
            : base(configuration)
        {
        }
        //Overrides the method from the base class
        public override bool ShouldExploreAction(string actionVariableValue, HttpActionDescriptor actionDescriptor, IHttpRoute route)
        {
            var includeAttribute = actionDescriptor.GetCustomAttributes<IncludeInApiExplorerAttribute>().FirstOrDefault(); //Get the given custom attribute from the action
            if (includeAttribute != null)
            {
                return includeAttribute.Value && MatchRegexConstraint(route, "action", actionVariableValue); //If it is not null read the includeAttribute.Value which is set in app.config and return true or false based on the includeAttribute.Value and MatchRegexConstraint return value
            }
            var includeControlAttribute = actionDescriptor.ControllerDescriptor.GetCustomAttributes<IncludeInApiExplorerAttribute>().FirstOrDefault(); //If the action does not have any given type of custom attribute then chekc it in the controller level
            if (includeControlAttribute != null)
            {
                return includeControlAttribute.Value && MatchRegexConstraint(route, "action", actionVariableValue);//Similar to action level
            }
            return true && MatchRegexConstraint(route, "action", actionVariableValue);
        }
        //This method is as it is in the base class
        private static bool MatchRegexConstraint(IHttpRoute route, string parameterName, string parameterValue)
        {
            IDictionary<string, object> constraints = route.Constraints;
            if (constraints != null)
            {
                object constraint;
                if (constraints.TryGetValue(parameterName, out constraint))
                {
                    string constraintsRule = constraint as string;
                    if (constraintsRule != null)
                    {
                        string constraintsRegEx = "^(" + constraintsRule + ")$";
                        return parameterValue != null && Regex.IsMatch(parameterValue, constraintsRegEx, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
                    }
                }
            }
            return true;
        }
    }
