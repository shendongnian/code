    _pager.PageSelected += (object sender, ViewPager.PageSelectedEventArgs e) =>
            {
                if (e.Position == 1)
                {
                    _pager.Adapter.NotifyDataSetChanged();
                }
            };
