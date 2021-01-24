    class HomeViewModel
    {
        HomeViewModel(IPageDisplay pageDisplay) {//constructor stuff}
    private void LoadOtherView()
    {
        // Instead of interacting with a whole ViewModel, we just use the interface
        _pageDisplay.ChangePageCommand.Execute(new ContactViewModel());
    }
