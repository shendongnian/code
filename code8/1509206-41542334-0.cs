     ItemModel objEditItem;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                objEditItem = new ItemModel();
                objEditItem = e.Parameter as ItemModel;
            }
        }
