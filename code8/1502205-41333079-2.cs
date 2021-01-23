    public static class Extensions
    {
        public static bool IsUserAuthenticated(this HttpRequest request)
        {
		    RequestValidator validator = new RequestValidator(); 
		    return validator.IsValid(request); 
        }
    }
