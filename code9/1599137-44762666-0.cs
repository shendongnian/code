    public static class HttpContextRequestData
    {
        public static string RequestGuid
        {
            get
            {
                if (HttpContext.Current.Items["RequestGuid"] == null)
                    return string.Empty;
                else
                    return HttpContext.Current.Items["RequestGuid"] as string;
            }
            set
            {
                HttpContext.Current.Items["RequestGuid"] = value;
            }
        }
        public static DateTime RequestInitiated
        {
            get
            {
                if (HttpContext.Current.Items["RequestInitiated"] == null)
                    return DateTime.Now;
                else
                    return Convert.ToDateTime(HttpContext.Current.Items["RequestInitiated"]);
            }
            set
            {
                HttpContext.Current.Items["RequestInitiated"] = value;
            }
        }
    }
