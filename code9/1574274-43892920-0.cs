    public class MyMvcRouteHandler : MvcRouteHandler
    {
        protected override SessionStateBehavior GetSessionStateBehavior(RequestContext requestContext)
        {
            if (someCondition)
            {
                return SessionStateBehavior.Required;
            }
            // fallback to default behavior
            return base.GetSessionStateBehavior(requestContext);
        }
    }
