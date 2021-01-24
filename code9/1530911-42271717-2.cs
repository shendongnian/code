    class page1ViewModel
    {
    public ICommand goSettings { get; set; }
    private readonly NavigationViewModel _navigationViewModel;
    public page1ViewModel(NavigationViewModel navigationViewModel)
    {
        _navigationViewModel = navigationViewModel;
        goSettings = new BaseCommand(OpenSettings);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    private void OpenSettings(object obj)
    {
       mainWindowViewModel.SelectedViewModel   = new page2ViewModel();
    }
