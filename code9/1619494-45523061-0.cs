    public static class Helper
    {
        public static string BodyClassForTabAndMethod()
        {
            string[] selectedTabAndMethod = GetSelectedTabAndMethod();
    
            string bodyClass = "";
    
            // Change the below switch statements based upon the controller/method name.
            switch (selectedTabAndMethod[0])
            {
                case "home":
                    switch (selectedTabAndMethod[1])
                    {
                        case "index":
                            return "IndexClass";
                        case "about":
                            return "AboutClass";
                        case "contact":
                            return "ContactClass";
                    }
                    break;
                case "account":
                    switch (selectedTabAndMethod[1])
                    {
                        case "login":
                            return "LoginClass";
                        case "verifycode":
                            return "VerifyCodeClass";
                    }
                    break;
            }
    
            return bodyClass;
        }
    
        public static string[] GetSelectedTabAndMethod()
        {
            string[] selectedTabAndMethod = new string[2]; // Create array and set default values.
            selectedTabAndMethod[0] = "home";
            selectedTabAndMethod[1] = "index";
    
            if (HttpContext.Current.Request.Url.LocalPath.Length > 1)
            {
                // Get the selected tab and method (without the query string).
                string tabAndMethod = HttpContext.Current.Request.Url.LocalPath.ToLower();
    
                // Remove the leading/trailing "/" if found.
                tabAndMethod = ((tabAndMethod.Substring(0, 1) == "/") ? tabAndMethod.Substring(1) : tabAndMethod);
                tabAndMethod = ((Right(tabAndMethod, 1) == "/") ? tabAndMethod.Substring(0, tabAndMethod.Length - 1) : tabAndMethod);
    
                // Convert into an array.
                if (tabAndMethod.Count(s => s == '/') == 1)
                {
                    string[] split = tabAndMethod.Split('/');
                    selectedTabAndMethod[0] = split[0];
                    selectedTabAndMethod[1] = split[1];
                }
            }
    
            return selectedTabAndMethod;
        }
    
        public static string Right(string value, int length)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
    
            return ((value.Length <= length) ? value : value.Substring(value.Length - length));
        }
    }
