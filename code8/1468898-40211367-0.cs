    public abstract class StyleRefExtension : MarkupExtension
    {
        protected static ResourceDictionary RD;
        public string ResourceKey { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue();
        }
        public object ProvideValue()
        {
            if (RD == null)
                throw new Exception(
                    @"You should define RD before usage. 
                Please make it in static constructor of extending class!");
            return RD[ResourceKey];
        }
    }
