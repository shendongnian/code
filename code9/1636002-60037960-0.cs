        public class AddCustomHeader : IRule 
        {
           public void ApplyRule(RewriteContext context) 
           {
               context.HttpContext.Response.Headers.Add("X-Developed-By", "Your Name");
               context.Result = RuleResult.ContinueRules;
           } 
        }
