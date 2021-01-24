    public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main, menu);
            var item = menu.FindItem(Resource.Id.action_search);
            var searchView = MenuItemCompat.GetActionView(item);
            _searchView = searchView.JavaCast<Android.Support.V7.Widget.SearchView>();
            _searchView.QueryTextChange += (s, e) => _adapter.Filter.InvokeFilter(e.NewText);
            _searchView.QueryTextSubmit += (s, e) =>
            {
                // Handle enter/search button on keyboard here
                Toast.MakeText(this, "Searched for: " + e.Query, ToastLength.Short).Show();
                e.Handled = true;
            };
            MenuItemCompat.SetOnActionExpandListener(item, new SearchViewExpandListener(_adapter));
            return true;
        }
        private class SearchViewExpandListener : Java.Lang.Object, MenuItemCompat.IOnActionExpandListener
        {
            private readonly IFilterable _adapter;
            public SearchViewExpandListener(IFilterable adapter)
            {
                _adapter = adapter;
            }
            public bool OnMenuItemActionCollapse(IMenuItem item)
            {
                _adapter.Filter.InvokeFilter("");
                return true;
            }
            public bool OnMenuItemActionExpand(IMenuItem item)
            {
                return true;
            }
        }
