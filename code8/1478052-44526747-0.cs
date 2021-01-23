    public class RewriteSubdomainRule : IRule
        {
            public void ApplyRule(RewriteContext context)
            {
                var request = context.HttpContext.Request;
                var host = request.Host.Host;
                // Check if the host is subdomain.domain.com or subdomain.localhost for debugging
                if (Regex.IsMatch(host, @"^[A-Za-z\d]+\.(?:[A-Za-z\d]+\.[A-Za-z\d]+|localhost)$"))
                {
                    string subdomain = host.Split('.')[0];
                    //modifying the request path to let the routing catch the subdomain
                    context.HttpContext.Request.Path = "/subdomain/" + subdomain + context.HttpContext.Request.Path;
                    context.Result = RuleResult.ContinueRules;
                    return;
                }
                context.Result = RuleResult.ContinueRules;
                return;
            }
        }
