    [AttributeUsage(AttributeTargets.Method)]
    public class BasicHttpAuthorizationAttribute : Attribute
    {
        bool requireSsl = true;
     
        public bool RequireSsl
        {
            get { return requireSsl; }
            set { requireSsl = value; }
        }
    }
