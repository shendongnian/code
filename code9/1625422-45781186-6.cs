	public static Task NavigateTo<T>(object navigationContext = null)
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
		
        /* newPage.BindingContext ?? */
        var viewModel = Activator.CreateInstance<T>();
        if (param != null)
            viewModel.SetNavigationContext(navigationContext);
        newPage.BindingContext = viewModel;
		var currentPage = ((NavigationPage)Current.MainPage).CurrentPage;
		return currentPage.Navigation.PushAsync(newPage);
	}
