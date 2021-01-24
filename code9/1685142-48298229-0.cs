    [ModelBinder(BinderType = typeof(ActionModelBinder))]
    public abstract class ActionBase
    {
        public string Type => GetType().FullName;
        public ActionBase Action { get; set; }
    }
