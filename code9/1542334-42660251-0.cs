    public async Task PushAsync(object page)
        {
            var xamarinPage = page as Page;
            if (xamarinPage == null)
                throw new Exception("PushAsync can not push a non Xamarin Page");
            if (page is MyPageName)
                await _page.Navigation.PushModalAsync(xamarinPage);
            await _page.PushAsync(xamarinPage);
        }
