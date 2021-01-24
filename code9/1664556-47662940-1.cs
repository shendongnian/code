        protected override void OnAppearing()
        {
            base.OnAppearing();
            // *STANDARD MASSIVE KLUGE* Needed to get initial selection to show.
            Item m = MyListView.SelectedItem as Item;
            MyListView.SelectedItem = null;
            MyListView.SelectedItem = m;
        }
