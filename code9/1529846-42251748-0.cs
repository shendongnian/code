    public class TypeNameLocalizer : ITypeNameLocalizer
    {
        private IStringLocalizer localizer;
        public TypeNameLocalizer(IStringLocalizer<Entities> localizer) 
        {
            this.localizer = localizer;
        }
        public string this[Type type] 
        { 
            get
            {
                return localizer[type.Name];
            }
        }
    }
