    public class AnonymousProfile : Profile
    {
        public AnonymousProfile()
        {
            AddConditionalObjectMapper().Where((s, d) => 
                s.IsAnonymousType() && s.Namespace != "System.Data.Entity.DynamicProxies");
        }
    }
