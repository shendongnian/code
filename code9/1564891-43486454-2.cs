        protected override async void OnAppearing ()
        {
            base.OnAppearing ();
            if(isPageLoaded)
                return;
            isPageLoaded = true;
            await pushAsyncPage(scanPage);
        }
