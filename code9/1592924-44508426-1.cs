        await Navigation.PushAsync(new YourMasterPage());
        var pages = Navigation.NavigationStack.ToList();
        foreach (var page in pages)
        {
            if (page.GetType() != typeof(YourMasterPage))
                Navigation.RemovePage(page);
        }
