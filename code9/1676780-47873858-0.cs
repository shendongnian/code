    var navigationStack = MainPage.Navigation.NavigationStack.ToList();
    var rootPage = navigationStack.FirstOrDefault();
    
    for (int i = navigationStack.Count - 1; i >= 0; i--)
    {
        var page = navigationStack[i];
        if (page.GetType() == rootPage.GetType())
        {
            return;
        }
        else
        {
            Navigation.RemovePage(page);
        }
    }
    Navigation.PopModalAsync(true)
