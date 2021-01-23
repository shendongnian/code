    public abstract class View
    {
        private IEnumerable<View> SubViews { get; }
        protected View(params View[] subViews)
        {
            SubViews = subViews;
        }
        public void Initialize()
        {
            OnInitialize();
            foreach (var view in SubViews)
            {
                view.Initialize();
            }
        }
        protected abstract void OnInitialize();
    }
