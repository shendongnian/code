    public class CustomServiceFilterAttribute : ServiceFilterAttribute
    {
        public string Param { get; set; }
        public CustomServiceFilterAttribute(Type type)
            : base(type)
        {
            
        }
    }
