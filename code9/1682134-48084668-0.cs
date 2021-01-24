    public class  DefaultPageModelResolver : IFreshPageModelResolver {
        public Page ResolvePageModel (Type type, object data) {
            return FreshPageModelResolver.ResolvePageModel(type, data);
        }
        //...code removed for brevity
    }
