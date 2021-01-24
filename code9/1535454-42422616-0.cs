        public static YourDbContext CurrentContext
        {
            get { return (YourDbContext) HttpContext.Current.Items[Sessionkey]; }
            private set { HttpContext.Current.Items[Sessionkey] = value; }
        }
