    public class SearchPageRenderer : ViewRenderer
    {
        private SearchView searchView;
    
        /// <summary>
        ///     Gets or sets the toolbar.
        /// </summary>
        private Android.Support.V7.Widget.Toolbar toolbar;
    
        ...
    
        /// <summary>
        ///     Reaction on the element changed event.
        /// </summary>
        /// <param name="e">The event argument.</param>
    
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            if (e?.NewElement == null || e.OldElement != null)
            {
                return;
            }
            this.AddSearchToToolBar();
        }
       
       ...
    
    }
