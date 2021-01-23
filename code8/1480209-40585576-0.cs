        [AttributeUsage(AttributeTargets.Method)]
        public class MissingParamAttribute : HandleErrorAttribute
        {
            private string _paramName;
    
            public MissingParamAttribute(string paramName)
            {
                _paramName = paramName;
            }
    
            public override void OnException(ExceptionContext filterContext)
            {
                if(filterContext.Exception is ArgumentException)
                {
                    const string pattern = @"The parameters dictionary contains a null entry for parameter '([^']+)'.+";
                    var match = Regex.Match(filterContext.Exception.Message, pattern, RegexOptions.Multiline);
                    if(match.Success && match.Groups[1].Value == _paramName)
                    {
                        filterContext.ExceptionHandled = true;
                        filterContext.HttpContext.Response.Clear();
                        filterContext.HttpContext.Response.StatusCode = 404;
                        return;
                    }
                }
                base.OnException(filterContext);
            }
        }
