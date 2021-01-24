    protected override void OnPause()
    {
        base.OnPause();
        //save the current page before app pauses, because Xamarin doesn't always call OnAppearing on the correct page when resume happens
        PageService.SavedStatePage = PageService.CurrentPage;
    } 
