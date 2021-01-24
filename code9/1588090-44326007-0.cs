    public static class SessionState
    {
        public List<string> Images
        {
            get
            {
                List<string> images = Session["Images"] as List<string>;
                return images;
            }
            set
            {
                Session["Images"] = value;
            }
        }
    }
