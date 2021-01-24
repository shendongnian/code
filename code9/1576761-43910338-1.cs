    public class AddCorsHeader : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            IEnumerable<string> origin;
            if (context.Request.Headers.TryGetValues("Origin", out origin))
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", origin);
            }
        }
    }
