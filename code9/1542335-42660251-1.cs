     public async Task PopAsync()
        {
            if (_page.Navigation.ModalStack.Count > 0)
            {
                var page = _page.Navigation.ModalStack[0];
                _page_Popped(null, new NavigationEventArgs(page));
                await _page.Navigation.PopModalAsync();
            }
            else
                await _page.PopAsync();
        }
        public async Task PushAsync(object page)
        {
            var xamarinPage = page as Page;
            if (xamarinPage == null)
                throw new Exception("PushAsync can not push a non Xamarin Page");
            if (page is ExrinSample.View.AboutView)
                await _page.Navigation.PushModalAsync(xamarinPage);
            else
                await _page.PushAsync(xamarinPage);
        }
