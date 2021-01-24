    public class ValidateJsonXssAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext?.Request;
            if (request != null && "application/json".Equals(request.ContentType, StringComparison.OrdinalIgnoreCase))
            {
                if (request.ContentLength > 0 && request.Form.Count == 0) // 
                {
                    if (request.InputStream.Position > 0)
                        request.InputStream.Position = 0; // InputStream has already been read once from "ProcessRequest"
                    using (var reader = new StreamReader(request.InputStream))
                    {
                        var postedContent = reader.ReadToEnd(); // Get posted JSON content
                        var isValid = RequestValidator.Current.InvokeIsValidRequestString(HttpContext.Current, postedContent,
                            RequestValidationSource.Form, "postedJson", out var failureIndex); // Invoke XSS validation
                        if (!isValid) // Not valid, so throw request validation exception
                            throw new HttpRequestValidationException("Potentially unsafe input detected");
                    }
                }
            }
        }
    }
	
