    public static class SessionState
    {
        public List<string> Images
        {
            get
            {
                return HttpContext.Current.Session["Images"] as List<string>;
            }
            set
            {
                HttpContext.Current.Session["Images"] = value;
            }
        }
    }
