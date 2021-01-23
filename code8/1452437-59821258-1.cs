    public async Task<T> NavigateToModal<T>(string modalName)
        {
            var source = new TaskCompletionSource<T>();
            if (modalName == nameof(NewItemPage))
            {
                var page = new NewItemPage();
                page.PageDisapearing += (result) =>
                {
                    var res = (T)Convert.ChangeType(result, typeof(T));
                    source.SetResult(res);
                };
                await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(page));
            }
            return await source.Task;
        }
