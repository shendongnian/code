    public static DoThings
    {
        public static void HandleRequest(Request r)
        {
            // Dynamic dispatch to actual method:
            HandleRequest((dynamic)r);
        }
        public static void HandleRequest(AudioRequest r)
        {
            // Do things.
        }
    
        public static void HandleRequest(VideoRequest r)
        {
            // Do things.
        }
    }
