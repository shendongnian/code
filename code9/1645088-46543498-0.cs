    class CustomSearchBar : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
                Control.Background = ContextCompat.GetDrawable(Forms.Context, Resource.Drawable.custom_search_view);
        }
    }
