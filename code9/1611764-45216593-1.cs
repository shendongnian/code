        private const string ContextKey = "current.session";
        public static YourDbContext CurrentContext
        {
            get { return (ISession) HttpContext.Current.Items[ContextKey]; }
            private set { HttpContext.Current.Items[ContextKey] = value; }
        }
