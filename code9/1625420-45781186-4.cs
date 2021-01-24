    public static Task NavigateTo<T>(object param = null)
        where T : BaseViewModel
    {
        // do some very simple navigation/lookups
        // basically, just remove the "Model" part of the VM and that is the page
        // "converntion-based" :)
        var viewModelName = typeof(T).Name;
        var pageType = typeof(MainView);
        var pageNamespace = pageType.Namespace;
        var pageAssembly = pageType.GetTypeInfo().Assembly;
        var newPageName = viewModelName.Substring(0, viewModelName.Length - "Model".Length);
        var newPageType = pageAssembly.GetType($"{pageNamespace}.{newPageName}");
        var newPage = Activator.CreateInstance(newPageType) as Page;
        if (param != null)
            NavigationContext.SetParam(newPage, param);
        var currentPage = ((NavigationPage)App.Current.MainPage).CurrentPage;
        return currentPage.Navigation.PushAsync(newPage);
    }
