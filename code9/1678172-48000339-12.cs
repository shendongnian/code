    public static class Global
    {
        // static constructor
        static Global()
        {
            // sub out static property value
            // TODO magic happens here - read in file, compile, and assign new values
            Apple = new Apple();
        }
        public static Apple Apple { get; set; }
    }
