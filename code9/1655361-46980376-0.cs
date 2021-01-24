    namespace Example.App.CustomExtensions 
    {
        public static class UriExtensions 
        {
            public static string ToRootHttpUriString(this Uri uri) 
            {
                if (!uri.IsHttp()) 
                {
                    throw new InvalidOperationException(...);
                }
    
                return uri.Scheme + "://" + uri.Authority;
            }
    
            public static string IsHttp(this Uri uri) 
            {
                return uri.Scheme == "http" || uri.Scheme == "https";
            }
        }
    }
