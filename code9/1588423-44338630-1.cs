    public class BindingConfig
    {
        public static void RegisterBinders(ModelBinderDictionary binders)
        {
            binders.Add(typeof(Guid), new GuidModelBinder());
            binders.Add(typeof(Guid?), new GuidModelBinder());
        }
    }
