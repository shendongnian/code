    private async void NotifyChange(string name)
    {
        if (!String.IsNullOrEmpty(searchString))
        {
            var products = await requestProductsAsync(searchString);
            SugestProducts = listToObservable(products);
        }
    }
