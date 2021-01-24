        protected override async void OnAppearing ()
        {
            base.OnAppearing ();
            await pushAsyncPage(scanPage);
        }
