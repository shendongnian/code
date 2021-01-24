    namespace Microsoft.AspNetCore.Http
    {
        public static class RequestExtension
        {
            public static string PathToRazorPageFolder(this HttpRequest request)
            {
                if (request != null) {
                    var requestPath = request.Path.ToString();
                    var returnPathToFolder = request.Scheme + "://" + request.Host + requestPath.Substring(0, requestPath.LastIndexOf("/")); ;
                    return returnPathToFolder;
                } else
                {
                    return "HttpRequest was null";
                }
            }
        }
    }
