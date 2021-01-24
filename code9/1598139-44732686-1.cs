    public class NameIdRouteConstraint : RegexRouteConstraint
    {
        public NameIdRouteConstraint() : base(@"([A-Za-z]{3})([0-9]{3})$")
        {
        }
    }
