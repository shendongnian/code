    public class View : IView
    {
        private IView portraitView;
        private IView landscapeView;
        // assign some values to sub-views 
        
        public virtual void Initialize()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var subViews = from field in GetType().GetFields(flags)
                           let value = field.GetValue(this)
                           where value != null && value is IView
                           select (IView)value;
            foreach (var subView in subViews)
                subView.Initialize();
        }
    }
