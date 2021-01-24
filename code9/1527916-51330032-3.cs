    public class ExtendedListViewRenderer : ListViewRenderer
    {
        /// <summary>
        /// The refresh layout that wraps the native ListView.
        /// </summary>
        private SwipeRefreshLayout _refreshLayout;
        public ExtendedListViewRenderer(Android.Content.Context context) : base(context)
        {
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _refreshLayout = null;
            }
            base.Dispose(disposing);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            _refreshLayout = (SwipeRefreshLayout)Control.Parent;
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == ListView.IsRefreshingProperty.PropertyName)
            {
                // Do not call base method: we are handling it manually
                UpdateIsRefreshing();
                return;
            }
            base.OnElementPropertyChanged(sender, e);
        }
        /// <summary>
        /// Updates SwipeRefreshLayout animation status depending on the IsRefreshing Element 
        /// property.
        /// </summary>
        protected void UpdateIsRefreshing()
        {
            // I'm afraid this method can be called after the ListViewRenderer is disposed
            // So let's create a new reference to the SwipeRefreshLayout instance
            SwipeRefreshLayout refreshLayoutInstance = _refreshLayout;
            if (refreshLayoutInstance == null)
            {
                return;
            }
            bool isRefreshing = Element.IsRefreshing;
            refreshLayoutInstance.Post(() =>
            {
                refreshLayoutInstance.Refreshing = isRefreshing;
            });
        }
    }
