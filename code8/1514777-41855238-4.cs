     public class ResultFilterAttribute : Attribute, IResultFilter
        {
            public async void OnResultExecuted(ResultExecutedContext context)
            {
                Stream bodyStream = context.HttpContext.Response.Body;
                bodyStream.Seek(0, SeekOrigin.Begin);
                string bodyText = rd.ReadToEnd();
            }
         }
